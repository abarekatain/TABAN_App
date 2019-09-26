using UnityEngine;
using System.Collections;
using System.Data;
using System.Runtime.InteropServices;
using System.IO;
using System;

public class ExportReport : MonoBehaviour
{

    [DllImport("user32.dll")]

    private static extern void SaveFileDialog(); //in your case : OpenFileDialog
    DataTable dt;


    public void ExportTheExcelFile()
    {
        System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();

        saveFileDialog1.Filter = "Excel File|*.xls";
        saveFileDialog1.Title = "Save Excel Export";
        saveFileDialog1.ShowDialog();

        // If the file name is not an empty string open it for saving.
        if (saveFileDialog1.FileName != "")
        {
            ToExcel(dt, saveFileDialog1.FileName);
        }


    }

    void SetTheDT()
    {
        dt.Reset();
        dt.Columns.Add(" ", Type.GetType("System.String"));
        dt.Rows.Add(dt.NewRow());
        dt.Rows[0][0] = "Time";
        dt.Rows[1][0] = "Velocity";
        dt.Rows[2][0] = "Re";
        dt.Rows[3][0] = "Cd";
        dt.Rows[4][0] = "Viscosity";


    }


    public void ToExcel(DataTable dt, string target)
    {

       //open file


        try
        {
            StreamWriter wr = new StreamWriter(target);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                wr.Write(dt.Columns[i].ToString().ToUpper() + "\t");
            }

            wr.WriteLine();

            //write rows to excel file
            for (int i = 0; i < (dt.Rows.Count); i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i][j] != null)
                    {
                        wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
                    }
                    else
                    {
                        wr.Write("\t");
                    }
                }
                //go to next line
                wr.WriteLine();
            }
            //close file
            wr.Close();

        }
        catch
        {

        }


    }

}
