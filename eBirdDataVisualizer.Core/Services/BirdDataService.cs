﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eBirdDataVisualizer.Core.Models;

namespace eBirdDataVisualizer.Core.Services;
public class BirdDataService
{
    static DataSet DataSet = new DataSet();
    static DataTable Birds = new DataTable(nameof(Birds));
    static DataColumn BirdId = new DataColumn(nameof(BirdId), typeof(Int32));
    static DataColumn CommonName = new DataColumn(nameof(CommonName), typeof(string));
    static DataColumn ScientificName = new DataColumn(nameof(ScientificName), typeof(string));
    static DataColumn Frequency = new DataColumn(nameof(Frequency), typeof(List<double>));

    private static List<Bird> allBirds;

    static BirdDataService()
    {
        Birds.Columns.Add(BirdId);
        Birds.Columns.Add(CommonName);
        Birds.Columns.Add(ScientificName);
        Birds.Columns.Add(Frequency);

        Birds.Rows.Add(0, "Black-bellied Whistling-Duck", "Dendrocygna autumnalis", new List<double>() { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 1.655E-4, 2.082E-4, 4.693E-4, 4.624E-4, 8.357E-4, 9.092E-4, 8.3E-5, 0.0012603, 0.0012944, 4.97E-5, 0.0015, 0.0010597, 4.18E-4, 7.671E-4, 1.218E-4, 6.09E-5, 0.0, 0.0, 0.0019542, 0.0, 4.4E-5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 });

        Birds.Rows.Add(1, "Emu", "Dromaius novaehollandiae", new List<double>() { 0.0, 0.0, 0.0, 0.0, 4.44E-5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 });

        Birds.Rows.Add(1, "Snow Goose", "Anser caerulescens", new List<double>() { 0.0164127, 0.0130752, 0.0147944, 0.0115589, 0.0134523, 0.0070272, 0.0060272, 0.0100091, 0.0097213, 0.0075751, 0.0053493, 0.0031462, 0.0010052, 6.83E-4, 6.52E-4, 4.76E-4, 4.164E-4, 7.41E-5, 3.391E-4, 2.279E-4, 1.186E-4, 8.3E-5, 1.8E-4, 0.0, 1.491E-4, 5.39E-5, 5.89E-5, 4.18E-5, 1.18E-4, 1.828E-4, 1.218E-4, 7.95E-5, 2.555E-4, 6.514E-4, 9.051E-4, 0.0011868, 0.0010745, 0.0026718, 0.0040783, 0.0059102, 0.0064931, 0.0110383, 0.0122762, 0.0232245, 0.0200967, 0.0151272, 0.0184791, 0.030209 });

        DataSet.Tables.Add(Birds);
    }

    public BirdDataService()
    {

    }

    private static IEnumerable<Bird> AllBirds()
    {
        List<Bird> birds = new List<Bird>();
        foreach (DataRow row in DataSet.Tables[DataSet.Tables.IndexOf(Birds)].Rows)
        {
            birds.Add(new Bird()
            {
                BirdId = (int)row[BirdId],
                CommonName = (string)row[CommonName],
                ScientificName = (string)row[ScientificName],
                Frequency = (List<double>)row[Frequency]
            });
        }
        return birds;
    }

    public async Task<IEnumerable<Bird>> GetGridDataAsync()
    {
        if (allBirds == null)
        {
            allBirds = new List<Bird>(AllBirds());
        }

        await Task.CompletedTask;
        return allBirds;
    }
}