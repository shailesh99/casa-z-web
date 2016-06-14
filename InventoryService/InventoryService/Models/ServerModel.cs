using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InventoryService.Models
{

    public class Col_Servers
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }

        [Required(ErrorMessage ="Server Name Required")]
        [Display(Name="Server Name*")]
        public string ServerName { get; set; }

        [Required(ErrorMessage = "Operating System Required")]
        [Display(Name ="Operating System*")]
        public string OperatingSystem { get; set; }

        [Required(ErrorMessage = "Location Required")]
        [Display (Name ="Location*")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Rack Number Required")]
        [Display(Name = "Rack*")]
        public int Rack { get; set; }

        [Required(ErrorMessage = "Uspace Number Required")]
        [Display(Name = "Uspace*")]
        public int Uspace { get; set; }
        public string IP1 { get; set; }
        public string IP2 { get; set; }
        public string IP3 { get; set; }
        public string Domain { get; set; }

        [Required(ErrorMessage = "RAM Size Required")]
        [Display(Name = "RAM in GBs*")]
        public int RAM { get; set; }

        [Display (Name ="Motherboard Type")]
        public string MainBoard { get; set; }

        [Display (Name ="CPU Type")]
        public string CPU { get; set; }

        [Display (Name ="Number of CPUs")]
        public Nullable<int> NumberOfCPU { get; set; }

        [Display (Name ="RAID Type")]
        public Nullable<int> RAID { get; set; }

        [Display (Name ="Number of Harddrives")]
        public Nullable<int> NumberOfHarddrives { get; set; }
        //public Harddrive[] HardDrives { get; set; }
        //public Vm[] VMs { get; set; }
        public List<Harddrive> HardDrives { get; set; }
        public List<Vm> VMs { get; set; }
    }

    public class Harddrive
    {
        public int Port { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }

        [Display(Name ="Serial Number")]
        public string SerialNumber { get; set; }
    }

    public class Vm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Operating System")]
        public string OperatingSystem { get; set; }
        public string Description { get; set; }
        public string IP1 { get; set; }
        public string IP2 { get; set; }
        public string IP3 { get; set; }
    }

}