using ParsingExel.Abstraction;
using ParsingExel.Entities;
using ParsingExel.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingExel.Parsing
{
    public static class Parsing2_3Doors
    {
        public static string AddtoDB2_3Doors(DataTable dt)
        {            
            List<Closet> closet = new List<Closet> { };            
            int row_Index = 0;            
            bool checkForDepth = false;
            decimal depth1_1 = 0;
            decimal depth1_2 = 0;
            decimal depth2_1 = 0;
            decimal depth2_2 = 0;

            while (row_Index < dt.Rows.Count)
            {
                if (dt.Rows[row_Index][1].ToString() != "")
                {
                    if (checkForDepth == false)
                    {
                        try
                        {
                            depth1_1 = Convert.ToDecimal(dt.Rows[row_Index][5].ToString().Replace("глубина ", ""));
                            depth1_2 = Convert.ToDecimal(dt.Rows[row_Index][6].ToString().Replace("глубина ", ""));
                            depth2_1 = Convert.ToDecimal(dt.Rows[row_Index][8].ToString().Replace("глубина ", ""));
                            depth2_2 = Convert.ToDecimal(dt.Rows[row_Index][9].ToString().Replace("глубина ", ""));
                            row_Index += 2;
                            checkForDepth = true;
                        }
                        catch
                        {
                            return "Ошибка в определении глубины.";
                        }
                    }
                    closet.Add(new Closet { });
                    int closetCurrentCell = closet.Count - 1;
                    try
                    {
                        closet[closetCurrentCell].Width = Convert.ToDecimal(dt.Rows[row_Index][1].ToString());
                        closet[closetCurrentCell].Height = Convert.ToDecimal(dt.Rows[row_Index][2].ToString());
                        closet[closetCurrentCell].DoorsNumber = Convert.ToInt32(dt.Rows[row_Index][3].ToString());
                        closet[closetCurrentCell].Type = (dt.Rows[row_Index][3].ToString() == "2") ? ClosetType.Doors2 : ClosetType.Doors3;
                        closet[closetCurrentCell].Depth = null;
                        closet[closetCurrentCell].Description = null;
                    }
                    catch
                    {
                        return "Ошибка в основном блоке.";
                    }

                    ClosetDepth asd = new ClosetDepth();
                    asd.Model = dt.Rows[row_Index][4].ToString();
                    asd.Closetdepth = depth1_1;
                    asd.ClosetDepthPrice = Convert.ToDecimal(dt.Rows[row_Index][5].ToString());
                    closet[closetCurrentCell].Closetdepth.Add(asd); //ОШИБКАААААААААААААААААААААААААААААААААААААААААААААА
                    int closetDepthCurrentCell = closet[closetCurrentCell].Closetdepth.Count - 1;
                    closet[closetCurrentCell].Closetdepth[closetDepthCurrentCell].Model = dt.Rows[row_Index][4].ToString();
                    closet[closetCurrentCell].Closetdepth[closetDepthCurrentCell].Closetdepth = depth1_1;
                    closet[closetCurrentCell].Closetdepth[closetDepthCurrentCell].ClosetDepthPrice = Convert.ToDecimal(dt.Rows[row_Index][5].ToString());

                    closet[closetCurrentCell].Closetdepth.Add(new ClosetDepth { });
                    closetDepthCurrentCell = closet[closetCurrentCell].Closetdepth.Count - 1;
                    closet[closetCurrentCell].Closetdepth[closetDepthCurrentCell].Model = dt.Rows[row_Index][4].ToString();
                    closet[closetCurrentCell].Closetdepth[closetDepthCurrentCell].Closetdepth = depth1_2;
                    closet[closetCurrentCell].Closetdepth[closetDepthCurrentCell].ClosetDepthPrice = Convert.ToDecimal(dt.Rows[row_Index][6].ToString());

                    closet[closetCurrentCell].Closetdepth.Add(new ClosetDepth { });
                    closetDepthCurrentCell = closet[closetCurrentCell].Closetdepth.Count - 1;
                    closet[closetCurrentCell].Closetdepth[closetDepthCurrentCell].Model = dt.Rows[row_Index][7].ToString();
                    closet[closetCurrentCell].Closetdepth[closetDepthCurrentCell].Closetdepth = depth2_1;
                    closet[closetCurrentCell].Closetdepth[closetDepthCurrentCell].ClosetDepthPrice = Convert.ToDecimal(dt.Rows[row_Index][8].ToString());

                    closet[closetCurrentCell].Closetdepth.Add(new ClosetDepth { });
                    closetDepthCurrentCell = closet[closetCurrentCell].Closetdepth.Count - 1;
                    closet[closetCurrentCell].Closetdepth[closetDepthCurrentCell].Model = dt.Rows[row_Index][7].ToString();
                    closet[closetCurrentCell].Closetdepth[closetDepthCurrentCell].Closetdepth = depth2_2;
                    closet[closetCurrentCell].Closetdepth[closetDepthCurrentCell].ClosetDepthPrice = Convert.ToDecimal(dt.Rows[row_Index][9].ToString());



                    try
                    {
                        closet[closetCurrentCell].Closetcolor.Add(new ClosetColor { });
                        int closetColorCurrentCell = closet[closetCurrentCell].Closetcolor.Count - 1;
                        closet[closetCurrentCell].Closetcolor[closetColorCurrentCell].color = ColorType.Sand;
                        closet[closetCurrentCell].Closetcolor[closetColorCurrentCell].ColorPrice = Convert.ToInt32(dt.Rows[row_Index][10].ToString());

                        closet[closetCurrentCell].Closetcolor.Add(new ClosetColor { });
                        closetColorCurrentCell = closet[closetCurrentCell].Closetcolor.Count - 1;
                        closet[closetCurrentCell].Closetcolor[closetColorCurrentCell].color = ColorType.Bambook;
                        closet[closetCurrentCell].Closetcolor[closetColorCurrentCell].ColorPrice = Convert.ToInt32(dt.Rows[row_Index][11].ToString());
                    }
                    catch
                    {
                        return "Ошибка в получении цены цвета.";
                    }

                    try
                    {
                        closet[closetCurrentCell].Closetamalgam.Add(new ClosetAmalgam { });
                        int closetAmalgamCurrentCell = closet[closetCurrentCell].Closetamalgam.Count - 1;
                        closet[closetCurrentCell].Closetamalgam[closetAmalgamCurrentCell].Amalgam = AmalgamType.Amalgam1;
                        closet[closetCurrentCell].Closetamalgam[closetAmalgamCurrentCell].AmalgamPrice = Convert.ToInt32(dt.Rows[row_Index][12].ToString());

                        closet[closetCurrentCell].Closetamalgam.Add(new ClosetAmalgam { });
                        closetAmalgamCurrentCell = closet[closetCurrentCell].Closetamalgam.Count - 1;
                        closet[closetCurrentCell].Closetamalgam[closetAmalgamCurrentCell].Amalgam = AmalgamType.Amalgam2;
                        closet[closetCurrentCell].Closetamalgam[closetAmalgamCurrentCell].AmalgamPrice = Convert.ToInt32(dt.Rows[row_Index][13].ToString());

                        closet[closetCurrentCell].Closetamalgam.Add(new ClosetAmalgam { });
                        closetAmalgamCurrentCell = closet[closetCurrentCell].Closetamalgam.Count - 1;
                        closet[closetCurrentCell].Closetamalgam[closetAmalgamCurrentCell].Amalgam = AmalgamType.Amalgam3;
                        closet[closetCurrentCell].Closetamalgam[closetAmalgamCurrentCell].AmalgamPrice = Convert.ToInt32(dt.Rows[row_Index][14].ToString());
                    }
                    catch
                    {
                        return "Ошибка в получении цены амальгамы.";
                    }

                    try
                    {
                        closet[closetCurrentCell].Closetglass.Add(new ClosetGlass { });
                        int closetGlassCurrentCell = closet[closetCurrentCell].Closetglass.Count - 1;
                        closet[closetCurrentCell].Closetglass[closetGlassCurrentCell].Glass = GlassType.Oracal;
                        closet[closetCurrentCell].Closetglass[closetGlassCurrentCell].GlassPrice = Convert.ToInt32(dt.Rows[row_Index][15].ToString());

                        closet[closetCurrentCell].Closetglass.Add(new ClosetGlass { });
                        closetGlassCurrentCell = closet[closetCurrentCell].Closetglass.Count - 1;
                        closet[closetCurrentCell].Closetglass[closetGlassCurrentCell].Glass = GlassType.Mirror;
                        closet[closetCurrentCell].Closetglass[closetGlassCurrentCell].GlassPrice = Convert.ToInt32(dt.Rows[row_Index][16].ToString());
                    }
                    catch
                    {
                        return "Ошибка в получении цены стекла.";
                    }
                                        
                    row_Index++;
                }
                else
                {
                    row_Index++;
                }
            }
            return "GOOD";
        }
    }
}
