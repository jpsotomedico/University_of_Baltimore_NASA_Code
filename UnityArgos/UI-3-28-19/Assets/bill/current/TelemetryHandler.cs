using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class TelemetryHandler : System.Object
{

    public int counterGet = 150;
    public int counterPost = 0;
    public static string Msg_toServer;
    public string json;
    public string jsonSwitch;
    public SUB_temperat sub_temp_script;
    public FAN_Tachometer fan_script;
    //  public SUB_Pressure sub_pressure_script;





    //telemerty data
    public string p_sub; //sub pressure (2-4psia)
    public string t_sub; // sub temperature (farenheit)
    public string v_fan; // fan tachometer (10,000-40,000 rpm)
    public string t_eva; //extravehicular activity time (less than 9 hours)
    public string p_o2; // oxygen pressure (750-950 psi)
    public string rate_o2; // oxygen use rate (0.5-1.0 psi/min)
    public string cap_battery; // battery capacity (0-30 amp/hr)[loss]
    public string p_h2o_g; // H2O gas pressure (14-16 psi)
    public string p_h2o_l; // H2O liquid pressure (14-16 psi)
    public string p_sop; //Secondary oxygen pressure (750-950 psia)
    public string rate_sop; // secodary oxygen use rate (0.5-1.0 psi/min)
    public string t_oxygen;
    public string t_battery;
    public string t_water;
    public string p_i;

    //telemetry switches

    public bool sop_on = false;
    public bool sspe = false;
    public bool fan_error = false;
    public bool vent_error = false;
    public bool vehicle_power = false;
    public bool h2o_off = false;
    public bool o2_off = false;





    void Start()
    {
        TelemetryHandler th = new TelemetryHandler();
        th.p_sub = "3.0";
        th.t_sub = "25.0";
        th.v_fan = "20000";
        th.t_eva = "1";
        th.p_o2 = "800.0";
        th.rate_o2 = "0.7";
        th.cap_battery = "5.0";
        th.p_h2o_g = "14.0";
        th.p_h2o_l = "16.0";
        th.p_sop = "900.0";
        th.rate_sop = "0.9";

        TelemetryHandler switches = new TelemetryHandler();

        string json = JsonUtility.ToJson(th);
        string jsonSwitch = JsonUtility.ToJson(switches);
        GameObject network = GameObject.Find("ConnectionHandler");
        UnityWebRequest www = UnityWebRequest.Put("http://localhost:3000/api/rawCoords", json);
        //what ever the ip is: the port/path, msg
    }
    // Update is called once per frame
    void Update()
    {
        if (counterGet == 300) // 5 sec  recieve request
        {
            TelemetryHandler switches = new TelemetryHandler();
            TelemetryHandler th = new TelemetryHandler();
            UnityWebRequest req = UnityWebRequest.Get("http://172.16.0.2:3000/api/suit/recent");
            UnityWebRequest sReq = UnityWebRequest.Get("http://172.16.0.2:3000/api/suitswitch/recent");
            Debug.Log(req.downloadHandler.text);
            json = req.downloadHandler.text;
            jsonSwitch = sReq.downloadHandler.text;

            switches = JsonUtility.FromJson<TelemetryHandler>(jsonSwitch);
            th = JsonUtility.FromJson<TelemetryHandler>(json);
            counterGet = 0;

        }
        if (counterPost == 300) // send info
        {
            TelemetryHandler th = new TelemetryHandler();
            TelemetryHandler switches = new TelemetryHandler();
            json = JsonUtility.ToJson(th);
            jsonSwitch = JsonUtility.ToJson(switches);

            UnityWebRequest www = UnityWebRequest.Put("http://localhost:3000/api/rawCoords", json);
            UnityWebRequest ww = UnityWebRequest.Put("http://localhost:3000/api/rawCoords", jsonSwitch);
            counterPost = 0;
        }
        counterGet++;
        counterPost++;

        // TODO: send th values to UI objects

        // update SUB Temperature UI

        GameObject sub_temp_obj = GameObject.Find("SUB Temperature");
        sub_temp_script = sub_temp_obj.GetComponent<SUB_temperat>();
        Debug.Log("TEMP: " + sub_temp_script.temp);


    }
}


