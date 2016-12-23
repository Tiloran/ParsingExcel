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
            int rowIndex = 0;
            double checkStringBegin = 0;
            int tablesComplete = 0; // Количество заполненных таблиц
            int lastRow = 0; //Строка на которой закачиваеться считывание для таблицы Curvilinear 

            while (tablesComplete != 8)
            {
                if (dt.Rows[rowIndex][2].ToString() != String.Empty && double.TryParse(dt.Rows[rowIndex][2].ToString(), out checkStringBegin) && tablesComplete == 0)
                { //Заполнение таблицы AdditionalCloset
                    while (dt.Rows[rowIndex][2].ToString() != String.Empty)
                    {
                        additionalcloset.Add(new AdditionalCloset
                        {
                            Model = dt.Rows[rowIndex][1].ToString(),
                            Width = Convert.ToDecimal(dt.Rows[rowIndex][2].ToString()),
                            Depth = dt.Rows[rowIndex][3].ToString(),
                            Height = dt.Rows[rowIndex][4].ToString(),
                            Price = Convert.ToDecimal(dt.Rows[rowIndex][5].ToString())
                        });
                        rowIndex++;
                    }
                    tablesComplete++;
                    rowIndex = 0;
                }
                if (dt.Rows[rowIndex][12].ToString() != String.Empty && double.TryParse(dt.Rows[rowIndex][12].ToString(), out checkStringBegin) && tablesComplete == 1)
                { //Заполнение таблицы Additional
                    byte endOfTable = 0; // Нужна для проверки, так как в екселе из-за обьединенных ячеек в ДатаТейбл есть пустые строки.
                    while (endOfTable < 3) // Если 3 строки подряд пустые, выход из цикла.
                    {
                        if (dt.Rows[rowIndex][12].ToString() != String.Empty)
                        {
                            additional.Add(new Additional
                            {
                                Name = dt.Rows[rowIndex][6].ToString(),
                                Price = dt.Rows[rowIndex][12].ToString()
                            });
                            endOfTable = 0;
                        }
                        else
                        {
                            endOfTable++;
                        }
                        rowIndex++;
                    }
                    tablesComplete++;
                    rowIndex = 0;
                }
                if (dt.Rows[rowIndex][7].ToString() != String.Empty && double.TryParse(dt.Rows[rowIndex][7].ToString(), out checkStringBegin) && tablesComplete == 2)
                { //Заполнение таблицы Rectilinear
                    int columnIndex = 6;
                    for (int i = 0; i < 6; i++)
                    {
                        rectilinear.Add(new Rectilinear
                        {
                            Parts = Convert.ToInt32(dt.Rows[rowIndex][columnIndex++].ToString().Substring(0, Convert.ToInt32(dt.Rows[rowIndex][6].ToString().IndexOf(' ')))),
                            Price = Convert.ToDecimal(dt.Rows[rowIndex][columnIndex++].ToString())
                        });
                        if (i == 2)
                        {
                            rowIndex++;
                            columnIndex = 6;
                        }
                    }
                    tablesComplete++;
                    rowIndex += 2;
                    columnIndex = 6;
                    //Заполнение таблицы Curvilinear                    
                    for (int i = 0; i < 4; i++)
                    {
                        curvilinear.Add(new Curvilinear
                        {
                            Parts = Convert.ToInt32(dt.Rows[rowIndex][columnIndex++].ToString().Substring(0, Convert.ToInt32(dt.Rows[rowIndex][6].ToString().IndexOf(' ')))),
                            Price = Convert.ToDecimal(dt.Rows[rowIndex][columnIndex++].ToString())
                        });
                        if (i == 1)
                        {
                            rowIndex++;
                            columnIndex = 6;
                        }
                    }
                    tablesComplete++;
                    lastRow = rowIndex; //????                    
                                         //Заполнение таблицы ColorPrice
                    columnIndex = 10;
                    rowIndex++;
                    while (true)
                    {
                        if (dt.Rows[rowIndex][12].ToString() != String.Empty && tablesComplete == 4)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                colorprice.Add(new ColorPrice
                                {
                                    Model = dt.Rows[rowIndex][columnIndex].ToString(),
                                    Price = Convert.ToDecimal(dt.Rows[rowIndex + 1][columnIndex++].ToString())
                                });
                            }
                            columnIndex = 10;
                            tablesComplete++;
                            //Заполнение таблицы PaintPrice
                            for (int i = 0; i < 3; i++)
                            {
                                paintprice.Add(new PaintPrice
                                {
                                    Model = dt.Rows[rowIndex][columnIndex].ToString(),
                                    Price = Convert.ToDecimal(dt.Rows[rowIndex + 2][columnIndex++].ToString())
                                });
                            }
                            tablesComplete++;
                            columnIndex = 1;
                                                        
                            string [] colors = (dt.Rows[rowIndex][columnIndex].ToString().Substring(dt.Rows[rowIndex][columnIndex].ToString().IndexOf(':') + 2).Trim('.')
                                .Split(new string[] { ", " }, StringSplitOptions.None));
                            string [] paints = (dt.Rows[rowIndex+1][columnIndex].ToString().Substring(dt.Rows[rowIndex+1][columnIndex].ToString().IndexOf(':') + 2).Trim('.')
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
                            rowIndex++;
                        }
                        if (tablesComplete == 8)
                            break;
                    }
                }
                rowIndex++;
            }

        }
    }
}

