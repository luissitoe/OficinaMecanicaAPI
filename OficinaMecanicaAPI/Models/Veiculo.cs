
﻿namespace OficinaMecanicaAPI.Models {

public class Veiculo {

    public Guid Id { get; set; }
    public required string Marca { get; set; }
    public required string Modelo { get; set; }
    public required string Cor { get; set; }
    public required string Matricula { get; set; }
    public required Cliente cliente { get; set; }

}

}