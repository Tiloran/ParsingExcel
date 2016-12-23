﻿using ParsingExel.Entities;
using ParsingExel.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace ParsingExel.Parsing
{
    public static class Parsing5Doors
    {
        public static string AddtoDB5Doors(DataTable dt)
        {
            const string DEEP = "глубина ";
            List<Closet> closet = new List<Closet> { };
            int rowIndex = 0;
            bool checkForDepth = false;
            decimal[] depth = new decimal[2];

            while (rowIndex < dt.Rows.Count)
            {
                if (dt.Rows[rowIndex][1].ToString() != String.Empty)
                {
                    if (checkForDepth == false)
                    {
                        try
                        {
                            depth[0] = Convert.ToDecimal(dt.Rows[rowIndex][5].ToString().Replace(DEEP, String.Empty));
                            depth[1] = Convert.ToDecimal(dt.Rows[rowIndex][6].ToString().Replace(DEEP, String.Empty));                            
                            checkForDepth = true;
                        }
                        catch
                        {
                            return "Ошибка в определении глубины.";
                        }
                    }
                    decimal checkForBeginOfString = 0;
                    if (!decimal.TryParse(dt.Rows[rowIndex][1].ToString(), out checkForBeginOfString))
                        rowIndex += 2;
                    closet.Add(new Closet { });
                    int closetCurrentCell = closet.Count - 1;
                    try
                    {
                        closet[closetCurrentCell].Width = Convert.ToDecimal(dt.Rows[rowIndex][1].ToString());
                        closet[closetCurrentCell].Height = Convert.ToDecimal(dt.Rows[rowIndex][2].ToString());
                        closet[closetCurrentCell].DoorsNumber = Convert.ToInt32(dt.Rows[rowIndex][3].ToString());
                        closet[closetCurrentCell].Type = ClosetType.Doors5;
                        closet[closetCurrentCell].Depth = null;
                        closet[closetCurrentCell].Description = null;
                    }
                    catch
                    {
                        return "Ошибка в основном блоке.";
                    }
                    try
                    {
                        GetDepth(closet, closetCurrentCell, dt, rowIndex, depth);
                    }
                    catch
                    {
                        return "Ошибка в получении модели или цены глубины.";
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
            for (int i = 0; i < 2; i++)
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

        private static void GetDepth(List<Closet> closet, int closetCurrentCell, DataTable dt, int rowIndex, decimal[] depth)
        {
            int columnIndexModel = 4;
            int columnIndexPrice = 5;
            for (int i = 0; i < 2; i++)
            {
                closet[closetCurrentCell].Closetdepth.Add(new ClosetDepth { });
                int closetDepthCurrentCell = closet[closetCurrentCell].Closetdepth.Count - 1;
                closet[closetCurrentCell].Closetdepth[closetDepthCurrentCell].Model = dt.Rows[rowIndex][columnIndexModel].ToString();
                closet[closetCurrentCell].Closetdepth[closetDepthCurrentCell].Closetdepth = depth[i];
                closet[closetCurrentCell].Closetdepth[closetDepthCurrentCell].ClosetDepthPrice =
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
