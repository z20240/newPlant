public class Item {
    private string name;
    private float rate;

    public Item (string name, float rate) {
        this.rate = rate;
        this.name = name;
    }

    public string Name {
        get { return name; }
        set { name = value; }
    }

    public float Rate {
        get { return rate; }
        set { rate = value; }
    }
}