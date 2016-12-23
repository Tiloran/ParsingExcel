using ParsingExel.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingExel.Parsing
{
    public static class ParsingAdditional
    {
        public static void AddToDBAdditional(DataTable dt)
        {
            List<AdditionalCloset> additionalcloset = new List<AdditionalCloset> { };
            List<Additional> additional = new List<Additional> { };
            List<Rectilinear> rectilinear = new List<Rectilinear> { };
            List<Curvilinear> curvilinear = new List<Curvilinear> { };
            List<StarkeColor> starkecolor = new List<StarkeColor> { };
            List<StarkePaint> starkepaint = new List<StarkePaint> { };
            List<ColorPrice> colorprice = new List<ColorPrice> { };
            List<PaintPrice> paintprice = new List<PaintPrice> { };
            int row_Index = 0;
            double checkStringBegin = 0;
            int tablesComplete = 0; // Количество заполненных таблиц
            int lastRow = 0; //Строка на которой закачиваеться считывание для таблицы Curvilinear 

            while (tablesComplete != 8)
            {
                if (dt.Rows[row_Index][2].ToString() != "" && double.TryParse(dt.Rows[row_Index][2].ToString(), out checkStringBegin) && tablesComplete == 0)
                { //Заполнение таблицы AdditionalCloset
                    while (dt.Rows[row_Index][2].ToString() != "")
                    {
                        additionalcloset.Add(new AdditionalCloset
                        {
                            Model = dt.Rows[row_Index][1].ToString(),
                            Width = Convert.ToDecimal(dt.Rows[row_Index][2].ToString()),
                            Depth = dt.Rows[row_Index][3].ToString(),
                            Height = dt.Rows[row_Index][4].ToString(),
                            Price = Convert.ToDecimal(dt.Rows[row_Index][5].ToString())
                        });
                        row_Index++;
                    }
                    tablesComplete++;
                    row_Index = 0;
                }
                if (dt.Rows[row_Index][12].ToString() != "" && double.TryParse(dt.Rows[row_Index][12].ToString(), out checkStringBegin) && tablesComplete == 1)
                { //Заполнение таблицы Additional
                    byte endOfTable = 0; // Нужна для проверки, так как в екселе из-за обьединенных ячеек в ДатаТейбл есть пустые строки.
                    while (endOfTable < 3) // Если 3 строки подряд пустые, выход из цикла.
                    {
                        if (dt.Rows[row_Index][12].ToString() != "")
                        {
                            additional.Add(new Additional
                            {
                                Name = dt.Rows[row_Index][6].ToString(),
                                Price = dt.Rows[row_Index][12].ToString()
                            });
                            endOfTable = 0;
                        }
                        else
                        {
                            endOfTable++;
                        }
                        row_Index++;
                    }
                    tablesComplete++;
                    row_Index = 0;
                }
                if (dt.Rows[row_Index][7].ToString() != "" && double.TryParse(dt.Rows[row_Index][7].ToString(), out checkStringBegin) && tablesComplete == 2)
                { //Заполнение таблицы Rectilinear
                    int columnIndex = 6;
                    for (int i = 0; i < 6; i++)
                    {
                        rectilinear.Add(new Rectilinear
                        {
                            Parts = Convert.ToInt32(dt.Rows[row_Index][columnIndex++].ToString().Substring(0, Convert.ToInt32(dt.Rows[row_Index][6].ToString().IndexOf(' ')))),
                            Price = Convert.ToDecimal(dt.Rows[row_Index][columnIndex++].ToString())
                        });
                        if (i == 2)
                        {
                            row_Index++;
                            columnIndex = 6;
                        }
                    }
                    tablesComplete++;
                    row_Index += 2;
                    columnIndex = 6;
                    //Заполнение таблицы Curvilinear                    
                    for (int i = 0; i < 4; i++)
                    {
                        curvilinear.Add(new Curvilinear
                        {
                            Parts = Convert.ToInt32(dt.Rows[row_Index][columnIndex++].ToString().Substring(0, Convert.ToInt32(dt.Rows[row_Index][6].ToString().IndexOf(' ')))),
                            Price = Convert.ToDecimal(dt.Rows[row_Index][columnIndex++].ToString())
                        });
                        if (i == 1)
                        {
                            row_Index++;
                            columnIndex = 6;
                        }
                    }
                    tablesComplete++;
                    lastRow = row_Index; //????                    
                                         //Заполнение таблицы ColorPrice
                    columnIndex = 10;
                    row_Index++;
                    while (true)
                    {
                        if (dt.Rows[row_Index][12].ToString() != "" && tablesComplete == 4)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                colorprice.Add(new ColorPrice
                                {
                                    Model = dt.Rows[row_Index][columnIndex].ToString(),
                                    Price = Convert.ToDecimal(dt.Rows[row_Index + 1][columnIndex++].ToString())
                                });
                            }
                            columnIndex = 10;
                            tablesComplete++;
                            //Заполнение таблицы PaintPrice
                            for (int i = 0; i < 3; i++)
                            {
                                paintprice.Add(new PaintPrice
                                {
                                    Model = dt.Rows[row_Index][columnIndex].ToString(),
                                    Price = Convert.ToDecimal(dt.Rows[row_Index + 2][columnIndex++].ToString())
                                });
                            }
                            tablesComplete++;
                            columnIndex = 1;
                                                        
                            string [] colors = (dt.Rows[row_Index][columnIndex].ToString().Substring(dt.Rows[row_Index][columnIndex].ToString().IndexOf(':') + 2).Trim('.')
                                .Split(new string[] { ", " }, StringSplitOptions.None));
                            string [] paints = (dt.Rows[row_Index+1][columnIndex].ToString().Substring(dt.Rows[row_Index+1][columnIndex].ToString().IndexOf(':') + 2).Trim('.')
                                .Split(new string[] { ", " }, StringSplitOptions.None));
                            //Заполнение таблицы StarkeColor
                            for (int i = 0; i < colors.Length; i++)
                            {
                                starkecolor.Add(new StarkeColor
                                {
                                    Color = colors[i]
                                });
                            }
                            tablesComplete++;
                            //Заполнение таблицы StarkePaint
                            for (int i = 0; i < paints.Length; i++)
                            {
                                starkepaint.Add(new StarkePaint
                                {
                                    Paint = paints[i]
                                });
                            }
                            tablesComplete++;

                        }
                        else
                        {
                            row_Index++;
                        }
                        if (tablesComplete == 8)
                            break;
                    }
                }
                row_Index++;
            }

        }
    }
}

