using System;
using System.Collections.Generic;

namespace Sample
{
    public class ViewModel
    {
        public List<Model> Data { get; set; }

        public List<Model> Data1 { get; set; }

        public List<Model> Data2 { get; set; }

        public List<Model> Data3 { get; set; }

        public List<Model> Data4 { get; set; }

        public ViewModel()
        {
            DateTime JanDateTime = new DateTime(2020, 01, 01); 
            DateTime FebDateTime = new DateTime(2020, 02, 01);
            DateTime MarchDateTime = new DateTime(2020, 03, 01);
            DateTime AprilDateTime = new DateTime(2020, 04, 01);
            DateTime MayDateTime = new DateTime(2020, 04, 01);
            Random random = new Random();
            Data = new List<Model>();
            for (int i = 0; i < 31; i++)
            {
                Data.Add(new Model { XValue = JanDateTime.AddDays(i), YValue = random.Next(0, 100) });
            };

            Data1 = new List<Model>();
            for (int j = 0; j < 28; j++)
            {
                Data1.Add(new Model { XValue = FebDateTime.AddDays(j), YValue = random.Next(0, 100) });
            };
            Data2 = new List<Model>();
            for (int i = 0; i < 31; i++)
            {
                Data2.Add(new Model { XValue = MarchDateTime.AddDays(i), YValue = random.Next(0, 100) });
            };

            Data3 = new List<Model>();
            for (int j = 0; j < 30; j++)
            {
                Data3.Add(new Model { XValue = AprilDateTime.AddDays(j), YValue = random.Next(0, 100) });
            };

            Data4 = new List<Model>();
            for (int j = 0; j < 31; j++)
            {
                Data4.Add(new Model { XValue = MayDateTime.AddDays(j), YValue = random.Next(0, 100) });
            };
        }
    }
}
