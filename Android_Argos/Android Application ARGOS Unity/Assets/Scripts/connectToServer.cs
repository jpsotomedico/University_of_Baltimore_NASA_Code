using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net;

public class connectToServer : MonoBehaviour
{
    NetworkClient myClient;
    public bool isAtStartup = true;
    private int counter = 58;


    // Update is called once per frame
    void Update()
    {
        if (isAtStartup)
        {
            SetupServer();
            SetupClient();
        }//end if setup
        else
        {
            if (counter == 60)
            {
                OnConnected();
                counter = 0;
            }
            counter++;
        }
    }//end update()

    public void SetupServer()
    {
        /*
        ConnectionConfig config = new ConnectionConfig();
        config.AddChannel(QosType.ReliableSequenced);
        config.AddChannel(QosType.Unreliable);
        NetworkServer.Configure(config, 1000);
        */
        NetworkServer.Listen(3000);
    }//end setupserver()

    public void SetupClient()
    {
        myClient = new NetworkClient();
        //myClient.RegisterHandler(MsgType.Connect, OnConnected);
        myClient.Connect("127.0.0.1", 3000);
        isAtStartup = false;
    }//end setupclient()


    public void OnConnected()
    {
        Debug.Log("We connected bih");
        /* Testing - Remove later */

        string dataFromMongoDB = "[{\"heart_bpm\":\"87\"," +
            "\"p_sub\":\"7.93\"," +
            "\"t_sub\":\"6\"," +
            "\"v_fan\":\"39907\"," +
            "\"p_o2\":\"15\"," +
            "\"rate_o2\":\"0.9\"," +
            "\"cap_battery\":\"29\"," +
            "\"p_h2o_g\":\"16\"," +
            "\"p_h2o_l\":\"16\"," +
            "\"p_sop\":\"947\"," +
            "\"rate_sop\":\"1.0\"," +
            "\"t_battery\":\" - 19:-44:-11\"," +
            "\"t_oxygen\":\"7:7:40\"," +
            "\"t_water\":\"7:7:40\"," +
            "\"create_date\":\"2019 - 04 - 03T21: 31:42.467Z\"}]";

        WebClient client = new WebClient();
        client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
        client.DownloadStringAsync(new System.Uri("http://172.16.0.2:3000/api/suit/recent"));
        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            dataFromMongoDB = e.Result;



            Debug.Log(dataFromMongoDB);


            if (dataFromMongoDB[0] == '[')
                dataFromMongoDB = dataFromMongoDB.Substring(1);
            if (dataFromMongoDB[dataFromMongoDB.Length - 1] == ']')
                dataFromMongoDB = dataFromMongoDB.Substring(0, dataFromMongoDB.Length - 1);

            Debug.Log("DATA: " + dataFromMongoDB);
            TelemetryHandler myTelemetryHandler = JsonUtility.FromJson<TelemetryHandler>(dataFromMongoDB);
            Debug.Log("Battery capacity: " + myTelemetryHandler.cap_battery);
            
            //eva handler
            int temp = System.Convert.ToInt32(myTelemetryHandler.t_sub);
            double pressure = System.Convert.ToDouble(myTelemetryHandler.p_sub);
            Debug.Log("Temperature: " + temp);
            int fan = System.Convert.ToInt32(myTelemetryHandler.v_fan);
            Debug.Log("P02: " + myTelemetryHandler.p_o2);
            
            //oxygen handler
            float primaryPressure = float.Parse(myTelemetryHandler.p_o2);
            float secondaryPressure = float.Parse(myTelemetryHandler.p_sop);
            float primaryUsageRate = float.Parse(myTelemetryHandler.rate_o2);
            float secondaryUsageRate = float.Parse(myTelemetryHandler.rate_sop);
           
            //battery handler
            float capacity = float.Parse(myTelemetryHandler.cap_battery);
            
            //internal suit pressure
            float suitPressure = float.Parse(myTelemetryHandler.p_i);
            
            //h20 handler
            float liquidpressure = float.Parse(myTelemetryHandler.p_h2o_l);
            float gaspressure = float.Parse(myTelemetryHandler.p_h2o_g);

            /*
            //SUB Temperature
            GameObject sub_info_obj = GameObject.Find("SUB Temperature");
            SubInfoScript sub_temp_script = sub_info_obj.GetComponent<SubInfoScript>();
            sub_temp_script.temp = temp;

            //SUB Pressure
            SubInfoScript sub_pressure_script = sub_info_obj.GetComponent<SubInfoScript>();
            sub_pressure_script.pressure = pressure;
            */

            //Fan tachometer
           GameObject fan_obj = GameObject.Find("FanTachometer");
            FAN_Tachometer fan_script = fan_obj.GetComponent<FAN_Tachometer>();
            fan_script.fan = fan;
            
            //Primary o2 pressure  & Secondary o2 pressure
            GameObject primaryO2_obj = GameObject.Find("OxygenInfo");
            OxygenControllerScript o2_script = primaryO2_obj.GetComponent<OxygenControllerScript>();
            o2_script.primaryPressure = primaryPressure;
            o2_script.secondaryPressure = secondaryPressure;
            o2_script.primaryUsageRate = primaryUsageRate;
            o2_script.secondaryUsageRate = secondaryUsageRate;
            o2_script.t_oxygen = myTelemetryHandler.t_oxygen;
            System.TimeSpan ts = System.TimeSpan.Parse(o2_script.t_oxygen);
            int t_oxygen_seconds = ts.Seconds;
            int t_oxygen_minutes = ts.Minutes;
            int t_oxygen_hours = ts.Hours;
            int o2_amount = t_oxygen_seconds + (t_oxygen_minutes * 60) + (t_oxygen_hours * 60 * 60);
            o2_script.o2Amount = o2_amount;


            //Battery handler
            GameObject battery_obj = GameObject.Find("battery_Capacity");
            BatteryScript battery_script = battery_obj.GetComponent<BatteryScript>();
            battery_script.capacity = capacity;
            battery_script.t_battery = myTelemetryHandler.t_battery;
            System.TimeSpan ts1 = System.TimeSpan.Parse(battery_script.t_battery);
            int t_battery_seconds = ts1.Seconds;
            int t_battery_minutes = ts1.Minutes;
            int t_battery_hours = ts1.Hours;
            int Battery_amount = t_battery_seconds + (t_battery_minutes * 60) + (t_battery_hours * 60 * 60);
            battery_script.BatteryAmount = Battery_amount;
            

            //Water handler
            GameObject h2o_obj = GameObject.Find("WaterInfo");
            WaterinfoScript h2o_script = h2o_obj.GetComponent<WaterinfoScript>();
            h2o_script.t_water = myTelemetryHandler.t_water;
            System.TimeSpan ts2 = System.TimeSpan.Parse(h2o_script.t_water);
            int t_water_seconds = ts2.Seconds;
            int t_water_minutes = ts2.Minutes;
            int t_water_hours = ts2.Hours;
            
            h2o_script.liquidPressure = liquidpressure;
            h2o_script.gasPressure = gaspressure;

            
            //internal suit pressure handler
            GameObject suit_pressure_obj = GameObject.Find("SuitPressure");
            InternalSuitPressureController suit_script = suit_pressure_obj.GetComponent<InternalSuitPressureController>();
            suit_script.suitPressure = suitPressure;



        
            /// End of remove later 
        }//end onconnected()
    }
}//end class

