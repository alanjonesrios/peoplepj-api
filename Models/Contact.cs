namespace peoplepj.Models
{
  public class Contact
  {
    public int ContactId { get; set; }
    public string Type { get; set; }
    public string Value { get; set; }

    public int PersonId { get; set; }

  }
}