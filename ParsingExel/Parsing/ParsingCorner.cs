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
    public static class ParsingCorner
    {
        public static string AddtoDBCorner(DataTable dt)
        {
            List<Closet> closet = new List<Closet> { };
            int rowIndex = 0;
            decimal[] depth = new decimal[2];
            decimal[] height = new decimal[2];
            int []depthAndHeightPostion = new int[2];
            for(int i = 0; i< dt.Rows.Count; i++)
            {
                if (dt.Rows[i][5].ToString().Contains("глубина"))
                    depthAndHeightPostion[0]=i;
                if (dt.Rows[i][5].ToString().Contains("высота"))
                    depthAndHeightPostion[1]=i;
            }
            try
            {
                depth[0] = Convert.ToDecimal(dt.Rows[depthAndHeightPostion[0]][5].ToString().Replace("глубина ", ""));
                depth[1] = Convert.ToDecimal(dt.Rows[depthAndHeightPostion[0]][6].ToString().Replace("глубина ", ""));
                height[0] = Convert.ToDecimal(dt.Rows[depthAndHeightPostion[1]][5].ToString().Replace("высота ", ""));
                height[1] = Convert.ToDecimal(dt.Rows[depthAndHeightPostion[1]][6].ToString().Replace("высота ", ""));
            }
            catch
            {
                return "Ошибка в определении глубины.";
            }


            while (rowIndex < dt.Rows.Count)
            {
                if (dt.Rows[rowIndex][1].ToString() != "")
                {                    
                    decimal checkForBeginOfString = 0;
                    if (!decimal.TryParse(dt.Rows[rowIndex][1].ToString(), out checkForBeginOfString))
                        rowIndex += 2;
                    closet.Add(new Closet { });
                    int closetCurrentCell = closet.Count - 1;
                    try
                    {
                        closet[closetCurrentCell].Width = Convert.ToDecimal(dt.Rows[rowIndex][1].ToString());
                        if (rowIndex < depthAndHeightPostion[0])
                        {
                            closet[closetCurrentCell].Height = Convert.ToDecimal(dt.Rows[rowIndex][2].ToString());
                        }
                        else
                        {
                            closet[closetCurrentCell].Depth = Convert.ToDecimal(dt.Rows[rowIndex][2].ToString());
                        }                        
                        closet[closetCurrentCell].DoorsNumber = Convert.ToInt32(dt.Rows[rowIndex][3].ToString());
                        closet[closetCurrentCell].Type = ClosetType.Doors5;                        
                        closet[closetCurrentCell].Description = null;
                    }
                    catch
                    {
                        return "Ошибка в основном блоке.";
                    }
                    try
                    {
                        GetDepthHeight(closet, closetCurrentCell, dt, rowIndex, depth, height, depthAndHeightPostion);
                    }
                    catch
                    {
                        return "Ошибка в получении модели или цены (глубины, высоты).";
                    }
                    try
                    {
                        GetColor(closet, closetCurrentCell, dt, rowIndex);
                    }
                    catch
                    {
                        return "Ошибка в получении цены цвета.";
                    }
                    try
                    {
                        GetAmalgam(closet, closetCurrentCell, dt, rowIndex);
                    }
                    catch
                    {
                        return "Ошибка в получении цены амальгамы.";
                    }
                    try
                    {
                        GetGlass(closet, closetCurrentCell, dt, rowIndex);
                    }
                    catch
                    {
                        return "Ошибка в получении цены стекла.";
                    }
                    rowIndex++;
                }
                else
                {
                    rowIndex++;
                }
            }
            return "GOOD";
        }

        private static void GetGlass(List<Closet> closet, int closetCurrentCell, DataTable dt, int rowIndex)
        {
            GlassType Glass = 0;
            int ColumnIndex = 12;
            for (int i = 0; i < 1; i++)
            {
                closet[closetCurrentCell].Closetglass.Add(new ClosetGlass { });
                int closetColorCurrentCell = closet[closetCurrentCell].Closetglass.Count - 1;
                closet[closetCurrentCell].Closetglass[closetColorCurrentCell].Glass = Glass++;
                closet[closetCurrentCell].Closetglass[closetColorCurrentCell].GlassPrice = Convert.ToDecimal(dt.Rows[rowIndex][ColumnIndex++].ToString());
            }
        }

        private static void GetAmalgam(List<Closet> closet, int closetCurrentCell, DataTable dt, int rowIndex)
        {
            AmalgamType amalgam = 0;
            int ColumnIndex = 9;
            for (int i = 0; i < 3; i++)
            {
                closet[closetCurrentCell].Closetamalgam.Add(new ClosetAmalgam { });
                int closetAmalgamCurrentCell = closet[closetCurrentCell].Closetamalgam.Count - 1;
                closet[closetCurrentCell].Closetamalgam[closetAmalgamCurrentCell].Amalgam = amalgam++;
                closet[closetCurrentCell].Closetamalgam[closetAmalgamCurrentCell].AmalgamPrice = Convert.ToDecimal(dt.Rows[rowIndex][ColumnIndex++].ToString());
            }
        }

        private static void GetDepthHeight(List<Closet> closet, int closetCurrentCell, DataTable dt, int rowIndex, decimal[] depth, decimal[] height, int[] depthAndHeightPostion)
        {
            int columnIndexModel = 4;
            int columnIndexPrice = 5;

            for (int i = 0; i < 2; i++)
            {
                if (columnIndexPrice == 5 && dt.Rows[rowIndex][columnIndexPrice].ToString() == "х")
                {
                    i++;
                    columnIndexPrice++;
                }
                else if(columnIndexPrice == 6 && dt.Rows[rowIndex][columnIndexPrice].ToString() == "х")
                {
                    break;
                }
                closet[closetCurrentCell].Closetcorner.Add(new ClosetCorner { });
                int closetDepthCurrentCell = closet[closetCurrentCell].Closetcorner.Count - 1;
                closet[closetCurrentCell].Closetcorner[closetDepthCurrentCell].Model = dt.Rows[rowIndex][columnIndexModel].ToString();
                if (rowIndex < depthAndHeightPostion[0])
                {
                    closet[closetCurrentCell].Closetcorner[closetDepthCurrentCell].ClosetCornerheight = height[i];
                }
                else
                {
                    closet[closetCurrentCell].Closetcorner[closetDepthCurrentCell].ClosetCornerdepth = depth[i];
                }                
                closet[closetCurrentCell].Closetcorner[closetDepthCurrentCell].ClosetCornerPrice =
                    Convert.ToDecimal(dt.Rows[rowIndex][columnIndexPrice++].ToString());
            }
        }

        private static void GetColor(List<Closet> closet, int closetCurrentCell, DataTable dt, int rowIndex)
        {
            ColorType Color = 0;
            int ColumnIndex = 7;
            for (int i = 0; i < 2; i++)
            {
                closet[closetCurrentCell].Closetcolor.Add(new ClosetColor { });
                int closetColorCurrentCell = closet[closetCurrentCell].Closetcolor.Count - 1;
                closet[closetCurrentCell].Closetcolor[closetColorCurrentCell].color = Color++;
                closet[closetCurrentCell].Closetcolor[closetColorCurrentCell].ColorPrice = Convert.ToDecimal(dt.Rows[rowIndex][ColumnIndex++].ToString());
            }
        }
    }
}
