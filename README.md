Steps for setting CRUD program

Install SSMS and SqL Server
Create Product table
Execute this in PM Console in visual studio to get ProductContext
Scaffold-DbContext "Server=DESKTOP-JH138N0;Database=Product;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Context -Context ProductContext -Force
 
