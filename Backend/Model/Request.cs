public class Request{
    public int Id { get; set; }
    public string requestUser { get; set; }

    public Request(string requestUser){
        this.requestUser = requestUser;
    }

}