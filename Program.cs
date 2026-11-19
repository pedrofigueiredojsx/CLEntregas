var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

var entregas = new List<Entrega>
{
    new(1, "João Silva", "Cuiabá", "Em trânsito"),
    new(2, "Maria Souza", "Várzea Grande", "Entregue")
};

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseHttpsRedirection();

app.MapGet("/api/entregas", () =>
{
    return Results.Ok(entregas);
});

app.MapGet("/api/entregas/{id:int}", (int id) =>
{
    var entrega = entregas.FirstOrDefault(e => e.Id == id);

    if (entrega is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(entrega);

});

app.MapPost("/api/entregas", (Entrega novaEntrega) =>
{
    entregas.Add(novaEntrega);

    return Results.Created(
        $"/api/entregas/{novaEntrega.Id}",
        novaEntrega
    );
});

app.MapPut("/api/entregas/{id:int}/status", (int id, AtualizarStatusRequest request) =>
{
    var entrega = entregas.FirstOrDefault(e => e.Id == id);

    if(entrega is null)
        return Results.NotFound();
    
    var statusPermitidos = new Dictionary<string, string>
    {
        { "Pendente", "Em trânsito" },
        { "Em trânsito", "Saiu para entrega" },
        { "Saiu para entrega", "Entregue" }
    };

    if (!statusPermitidos.TryGetValue(entrega.Status, out var proximoStatus) || proximoStatus != request.NovoStatus)
    {
        return Results.BadRequest("Transição de status inválida.");
    }

    entrega.Status = request.NovoStatus;

    return Results.Ok(entrega);
});


app.Run();

