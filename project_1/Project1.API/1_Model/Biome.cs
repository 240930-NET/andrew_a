using Microsoft.EntityFrameworkCore;

namespace Project1.API.Model;

public class Biome {
    public int ID {get; set;}
    public string Name {get; set;} = "";
    public double Temperature {get; set;} = 70.0;
    public double Humidity {get; set;} = 0.5;
}