using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeterne_OOP
{
    class Planet
    {

        private string name;
        private double mass;
        private double diameter;
        private double density;
        private double gravity;
        private double rotationperiod;
        private double lengthofday;
        private double distancefromsun;
        private double orbitalperiod;
        private double orbitalvelocity;
        private double meantemperature;
        private double numberofmoons;
        private bool ringsystem;


        public string Name
        {
            set
            {
                this.name = value;
            }
            get
            {
                return name;
            }
        }
        public double Mass
        {
            set
            {
                this.mass = value;
            }
            get
            {
                return mass;
            }
        }
        public double Diameter
        {
            set
            {
                this.diameter = value;
            }
            get
            {
                return diameter;
            }
        }
        public double Density
        {
            set
            {
                this.density = value;
            }
            get
            {
                return density;
            }
        }
        public double Gravity
        {
            set
            {
                this.gravity = value;
            }
            get
            {
                return gravity;
            }
        }
        public double Rotationperiod
        {
            set
            {
                this.rotationperiod = value;
            }
            get
            {
                return rotationperiod;
            }
        }
        public double Lengthofday
        {
            set
            {
                this.lengthofday = value;
            }
            get
            {
                return lengthofday;
            }
        }
        public double Distancefromsun
        {
            set
            {
                this.distancefromsun = value;
            }
            get
            {
                return distancefromsun;
            }
        }
        public double Orbitalperiod
        {
            set
            {
                this.orbitalperiod = value;
            }
            get
            {
                return orbitalperiod;
            }
        }
        public double Orbitalvelocity
        {
            set
            {
                this.orbitalvelocity = value;
            }
            get
            {
                return orbitalvelocity;
            }
        }
        public double Meantemperature
        {
            set
            {
                this.meantemperature = value;
            }
            get
            {
                return meantemperature;
            }
        }
        public double Numberofmoons
        {
            set
            {
                this.numberofmoons = value;
            }
            get
            {
                return numberofmoons;
            }
        }
        public bool Ringsystem
        {
            set
            {
                this.ringsystem = value;
            }
            get
            {
                return ringsystem;
            }
        }






    }
}
