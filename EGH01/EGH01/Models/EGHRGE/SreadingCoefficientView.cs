using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EGH01DB.Types;

namespace EGH01.Models.EGHRGE
{
    public class SpreadingCoefficientView
    {
        public int list_groundType { get;set; }     // тип грунта 
        public float min_volume { get; private set; }           // нижняя граница диапазона пролива   
        public float max_volume { get; private set; }           // верхняя граница диапазона пролива 
        public float min_angle { get; private set; }            // книжняя граница диапазона углов наклона 
        public float max_angle { get; private set; }            // верхняя граница диапазона углов наклона 
        public float koef { get; private set; }                 // коэффициент разлива в диапазоне 
	}
}