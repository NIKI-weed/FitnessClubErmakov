using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FitnessClubErmakov.DataBase;
using FitnessClubErmakov.Windows;

namespace FitnessClubErmakov.ClassHelper
{
    internal class EFClass
    {
        public static FitnessClubEntities context { get; set; } = new FitnessClubEntities();
    }
}
