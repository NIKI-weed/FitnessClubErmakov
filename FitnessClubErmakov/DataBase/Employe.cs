//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FitnessClubErmakov.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employe
    {
        public int IdEmploye { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Patronimic { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string GenderCode { get; set; }
        public string PhotoPath { get; set; }
        public Nullable<int> IdUser { get; set; }
        public System.DateTime BirthdayDate { get; set; }
    
        public virtual UserAuth UserAuth { get; set; }
    }
}
