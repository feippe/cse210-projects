public class Circle : Shape {
    private double _radius;

    public Circle(string color, double radius):base(color){
        _radius = radius;
    }

    public double GetRadius(){
        return _radius;
    }
    public void SetRadius(double radius){
        _radius = radius;
    }

    public override double GetArea(){
        return _radius * _radius * 3.14159265359;
    }


}