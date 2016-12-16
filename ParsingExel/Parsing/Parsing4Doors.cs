using ParsingExel.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingExel.Parsing
{
    public static class Parsing4Doors
    {
        public static void AddtoDB4Doors(DataTable dt)
        {
            List<Furniture> furniture = new List<Furniture> { };
            List<Closed> closed = new List<Closed> { };
            List<ListOfClosedDepth> ListDepth = new List<ListOfClosedDepth> { };
            int Row_Index = 0;
            int Closedid = 0;

            while (Row_Index < dt.Rows.Count)
            {
                if (dt.Rows[Row_Index][1].ToString() != "")
                {
                    furniture.Add(new Furniture
                    {
                        NameType = "Шкаф-купе",
                        Width = Convert.ToDecimal(dt.Rows[Row_Index][1].ToString()),
                        Height = Convert.ToDecimal(dt.Rows[Row_Index][2].ToString())
                    });
                    closed.Add(new Closed
                    {
                        ClosedID = Closedid,
                        DoorsNumber = Convert.ToInt32(dt.Rows[Row_Index][3].ToString()),
                        SandPrice = Convert.ToDecimal(dt.Rows[Row_Index][10].ToString()),
                        BambPrice = Convert.ToDecimal(dt.Rows[Row_Index][11].ToString()),
                        Amalgam1Price = Convert.ToDecimal(dt.Rows[Row_Index][12].ToString()),
                        Amalgam2Price = Convert.ToDecimal(dt.Rows[Row_Index][13].ToString()),
                        Amalgam3Price = Convert.ToDecimal(dt.Rows[Row_Index][14].ToString()),
                        OraPrice = Convert.ToDecimal(dt.Rows[Row_Index][15].ToString()),
                        MirPrice = Convert.ToDecimal(dt.Rows[Row_Index][16].ToString())
                    });
                    ListDepth.Add(new ListOfClosedDepth { });
                    int ListCurrentCell = ListDepth.Count - 1;
                    ListDepth[ListCurrentCell].depth.Add(new ClosedDepth
                    {
                        Model = dt.Rows[Row_Index][4].ToString(),
                        Closeddepth = 600,
                        ClosedDepthPrice = Convert.ToDecimal(dt.Rows[Row_Index][5].ToString()),
                        ClosedID = Closedid
                    });
                    ListDepth[ListCurrentCell].depth.Add(new ClosedDepth
                    {
                        Model = dt.Rows[Row_Index][4].ToString(),
                        Closeddepth = 450,
                        ClosedDepthPrice = Convert.ToDecimal(dt.Rows[Row_Index][6].ToString()),
                        ClosedID = Closedid
                    });
                    ListDepth[ListCurrentCell].depth.Add(new ClosedDepth
                    {
                        Model = dt.Rows[Row_Index][7].ToString(),
                        Closeddepth = 600,
                        ClosedDepthPrice = Convert.ToDecimal(dt.Rows[Row_Index][8].ToString()),
                        ClosedID = Closedid
                    });
                    ListDepth[ListCurrentCell].depth.Add(new ClosedDepth
                    {
                        Model = dt.Rows[Row_Index][7].ToString(),
                        Closeddepth = 450,
                        ClosedDepthPrice = Convert.ToDecimal(dt.Rows[Row_Index][9].ToString()),
                        ClosedID = Closedid++
                    });
                    Row_Index++;
                }
                else
                {
                    Row_Index++;
                }
            }
        }
    }
}
