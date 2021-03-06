﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection;
using AbstractFactory;


namespace Main
{
    class Program
    {
        // Main処理
        static void Main(string[] args)
        {

            if (args.Length != 2)
            {
                //第1引数：アセンブリ名　第2引数：名前空間.クラス名
                Console.WriteLine("Example 1: C# AbstractFactory ListFactory ListFactory.ListFactory");
                Console.WriteLine("Example 2: C# AbstractFactory ListFactory.TableFactory");
                Environment.Exit(0);
            }



            Factory AbstractFactory = Factory.GetFactory(args[0], args[1]);
            Link asahi = AbstractFactory.CreateLink("朝日新聞", "http://www.asashi.com/");
            Link yomiuri = AbstractFactory.CreateLink("読売新聞", "http://www.yomiuri.co.jp/");

            Link usYahoo = AbstractFactory.CreateLink("Yahoo!", "http://www.yahoo.com/");
            Link jpYahoo = AbstractFactory.CreateLink("Yahoo!Japan", "http://www.yahoo.co.jp/");
            Link excite = AbstractFactory.CreateLink("Excite", "http://www.excite.co.jp/");
            Link google = AbstractFactory.CreateLink("Google", "http://www.google.com/");

            Tray traynews = AbstractFactory.CreateTray("新聞");
            traynews.Add(asahi);
            traynews.Add(yomiuri);

            Tray trayyahoo = AbstractFactory.CreateTray("Yahoo!");
            trayyahoo.Add(usYahoo);
            trayyahoo.Add(jpYahoo);

            Tray traysearch = AbstractFactory.CreateTray("サーチエンジン");
            traysearch.Add(trayyahoo);
            traysearch.Add(excite);
            traysearch.Add(google);

            Page page = AbstractFactory.CreatePage("LinkPage", "AbstractFactory Sample");
            page.Add(traynews);
            page.Add(traysearch);
            page.Output(args[1]);

            // 実行が一瞬で終わって確認ため、キーの入力を待ちます
            Console.ReadLine();
        }
    }
}
