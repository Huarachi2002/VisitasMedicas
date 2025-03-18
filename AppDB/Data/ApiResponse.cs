namespace BackendVisitaNET.Data
{
    public class ApiResponse<T>
    {
        // Indica si la operación fue exitosa o no
        public bool Success { get; set; }

        // Mensaje descriptivo (de éxito o de error)
        public string Message { get; set; }

        // Datos en caso de éxito (puede ser un objeto o lista)
        public T Data { get; set; }

        // Objeto de error en caso de fallo (puedes usarlo para detalles)
        public object Error { get; set; }
    }

}
