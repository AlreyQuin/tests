﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTest
{
    public class DataGroup : IEquatable<DataGroup>, IComparable<DataGroup>
    {
        private string name;
        private string header = "";
        private string footer = "";

        public DataGroup(string name)
        {
            this.name = name;
        }

        public bool Equals(DataGroup other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(DataGroup other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }


        public string Name
        {
            get {
                return name;}
            set {
                name = value;}
        }

        public string Header
        {
            get {
                return header;}
            set {
                header = value;}
        }

        public string Footer
        {
            get {
                return footer;}
            set {
                footer = value;}
        }
    }
}