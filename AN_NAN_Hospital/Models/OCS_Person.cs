namespace OnCube_Switch.Models;

using System.Diagnostics;
using System.Runtime.CompilerServices;
using static OnCube_Switch.FileOutput;




/// <summary>
/// 放置OnCube成員，輸入後都去掉頭尾空白
/// </summary>


public class OCS_Person
{


    private string patient_name = string.Empty;         //###"1"
    public string Patient_Name
    {
        get { return patient_name; }

        set { patient_name = value.Trim(); }


    }

    private string patient_iD = "";          //###"2"
    public string Patient_ID
    {
        get { return patient_iD; }

        set { patient_iD = value.Trim(); }
    }

    private string patient_location = "";       //###"3"
    public string Patient_Location
    {
        get { return patient_location; }
        set { patient_location = value.Trim(); }
    }

    private string doctor_name = "";              //###"4"

    public string Doctor_Name
    {
        get { return doctor_name; }
        set { doctor_name = value; }

    }
    private string but = "";                  //###"5"
    public string BUT
    {
        get { return but; }
        set { but = value; }
    }

    private float quantity;                 //###"6"
    public float Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    private string drug_code = "";                //###"7"
    public string Drug_Code
    {
        get { return drug_code; }
        set { drug_code = value; }

    }


    private string medicine_name = "";            //###"8"
    public string Medicine_Name
    {
        get { return medicine_name; }

        set { medicine_name = value; }
    }

    private string admin_time = "";               //###"9"
    public string Admin_Time
    {
        get { return admin_time; }
        set { admin_time = value; }
    }
    private DateTime start_date;
    public DateTime StartDate
    {
        get { return start_date; }
        set { start_date = value; }
    }
    private DateTime stop_date;
    public DateTime StopDate
    {
        get { return stop_date; }
        set { stop_date = value; }

    }
    private string note = "";
    public string Note
    {
        get { return note; }
        set { note = value; }
    }

    private string admin_time_description = "";
    public string Admin_Time_description
    {
        get { return admin_time_description; }
        set { admin_time = value; }
    }

    private string prescription_number = "";
    public string Prescription_Number
    {
        get { return prescription_number; }
        set { prescription_number = value; }
    }

    private string english_petient_name = "";
    public string English_Patient_Name
    {
        get { return english_petient_name; }
        set { english_petient_name = value; }
    }


    private DateTime birthday;
    public DateTime BirthDate
    {
        get { return birthday; }
        set { birthday = value; }
    }

    private string sex = "";
    public string Sex
    {
        get { return sex; }
        set { sex = value; }
    }


    private string room_number = "";
    public string Room_Number
    {
        get { return room_number; }
        set { room_number = value; }
    }

    private string bed_number = "";
    public string Bed_Number
    {
        get { return bed_number; }
        set { bed_number = value; }
    }

    private string unitdose_state = "";   //他只有一個東西
    public string UnitDose_State
    {
        get { return unitdose_state; }
        set { unitdose_state = value; }
    }

    private string hospital_name = "";
    public string Hospital_Name
    {
        get { return hospital_name; }
        set { hospital_name = value; }
    }

    private string random_1 = "";
    public string Random_1
    {
        get { return random_1; }
        set { random_1 = value; }

    }

    private string random_2 = "";
    public string Random_2
    {
        get { return random_2; }
        set { random_2 = value; }

    }

    private string random_3 = "";
    public string Random_3
    {
        get { return random_3; }
        set { random_3 = value; }

    }

    private string random_4 = "";
    public string Random_4
    {
        get { return random_4; }
        set { random_4 = value; }

    }

    private string random_5 = "";
    public string Random_5
    {
        get { return random_5; }
        set { random_5 = value; }

    }

    private string random_6 = "";
    public string Random_6
    {
        get { return random_6; }
        set { random_6 = value; }

    }


    private string random_7 = "";
    public string Random_7
    {
        get { return random_7; }
        set { random_7 = value; }

    }

    private string random_8 = "";
    public string Random_8
    {
        get { return random_8; }
        set { random_8 = value; }

    }
    private string random_9 = "";
    public string Random_9
    {
        get { return random_9; }
        set { random_9 = value; }

    }

    private string random_10 ="";
    public string Random_10
    {
        get { return random_10; }
        set { random_10 = value; }
    }

    private string random_11 = "";
    public string Random_11
    {
        get { return random_11; }
        set { random_11 = value; }
    }

    private string random_12 = "";
    public string Random_12
    {
        get { return random_12; }
        set { random_12 = value; }
    }

    private string random_13 = "";
    public string Random_13
    {
        get { return random_13; }
        set { random_13 = value; }
    }

    private string random_14 = "";
    public string Random_14
    {
        get { return random_14; }
        set { random_14 = value; }
    }

    private string random_15 = "";
    public string Random_15
    {
        get { return random_15; }
        set { random_15 = value; }
    }

    private string dose_type = "";
    public string Dose_Type
    {
        get { return dose_type; }
        set { dose_type = value; }
    }
}