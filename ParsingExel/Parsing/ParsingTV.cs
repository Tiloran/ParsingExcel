//using ParsingExel.Entities;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ParsingExel.Parsing
//{
//    public static class ParsingTV
//    {

//        public static void AddtoDBTV (DataTable dt)
//        {
//            List<Furniture> furniture = new List<Furniture> { };
//            List<Closet> closed = new List<Closet> { };
//            List<ListOfClosetOptions> ListOption = new List<ListOfClosetOptions> { };
//            int row_Index = 0;
//            int closedId = 0;
//            double CheckToParse;

//            while (row_Index < dt.Rows.Count)
//            {
//                if (dt.Rows[row_Index][1].ToString() != "" && double.TryParse(dt.Rows[row_Index][1].ToString(), out CheckToParse))
//                {
//                    furniture.Add(new Furniture
//                    {
//                        NameType = "Шкаф-купе",
//                        Width = Convert.ToDecimal(dt.Rows[row_Index][1].ToString()),
//                        Height = Convert.ToDecimal(dt.Rows[row_Index][2].ToString())
//                    });
//                    closed.Add(new Closet
//                    {
//                        ClosetId = closedId,
//                        DoorsNumber = Convert.ToInt32(dt.Rows[row_Index][3].ToString()),
//                        Type = "шкаф TV",
//                        SandPrice = Convert.ToDecimal(dt.Rows[row_Index][9].ToString()),
//                        BambPrice = Convert.ToDecimal(dt.Rows[row_Index][10].ToString()),
//                        Amalgam1Price = Convert.ToDecimal(dt.Rows[row_Index][11].ToString()),
//                        Amalgam2Price = Convert.ToDecimal(dt.Rows[row_Index][12].ToString()),
//                        Amalgam3Price = Convert.ToDecimal(dt.Rows[row_Index][13].ToString()),
//                        OraPrice = Convert.ToDecimal(dt.Rows[row_Index][14].ToString()),
//                        MirPrice = Convert.ToDecimal(dt.Rows[row_Index][15].ToString())
//                    });
//                    ListOption.Add(new ListOfClosetOptions { });
//                    int ListCurrentCell = ListOption.Count - 1;
//                    ListOption[ListCurrentCell].DepthTV.Add(new ClosetTVDepth
//                    {
//                        Model = dt.Rows[row_Index][4].ToString(),
//                        ClosetTVdepth = 550,
//                        ClosetTVDepth1Price = Convert.ToDecimal(dt.Rows[row_Index][5].ToString()),
//                        ClosetTVDepth2Price = Convert.ToDecimal(dt.Rows[row_Index][6].ToString()),
//                        ClosetTVDepth3Price = Convert.ToDecimal(dt.Rows[row_Index][7].ToString()),
//                        DoorsWidth = Convert.ToDecimal(dt.Rows[row_Index][8].ToString()),
//                        ClosetId = closedId++
//                    });                    
//                    row_Index++;
//                }
//                else
//                {
//                    row_Index++;
//                }
//            }
//        }
//    }
//}
