# evisitor-dotnet

Simple .NET SDK for <a href="https://www.evisitor.hr">eVisitor</a>.
It has only few features I needed, but pull requests will be accepted.

Example of usage:


    Authentication auth=new Authentication("username","password");
    
    Client client=new Client(auth);
    
    var touristTaxCategories=client.TouristTaxCategories();
    
    or  
    
    var listOfTourist=client.ListOfTourist();      
    
    etc.


