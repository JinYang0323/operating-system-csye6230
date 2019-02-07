using System;

public enum Cusine {Indian, Chinese, American, French, Thai, Mexican}
class FoodItem {
    public int Price {get; set;}
    public string Name {get; set;}
    public Cusine cusine{get; set;}
}