namespace store.Messages
{
    public static class MessagesClass
    {
        // Mensajes de éxito
        public static string SuccessCreate() =>
           "El registro ha sido creado exitosamente.";

        public static string SuccessUpdate() =>
            "El registro ha sido actualizado exitosamente.";

        public static string SuccessDelete() =>
            "El registro ha sido eliminado exitosamente.";

        public static string SuccessGet() =>
            "Los datos han sido obtenidos exitosamente.";

        public static string SuccessNoContent() =>
            "No se encontraron datos para mostrar.";

        // Mensajes de error
        public static string ErrorCreate() =>
            "Hubo un error al intentar crear el registro.";

        public static string ErrorUpdate() =>
            "Hubo un error al intentar actualizar el registro.";

        public static string ErrorDelete() =>
            "Hubo un error al intentar eliminar el registro.";

        public static string ErrorGet() =>
            "Hubo un error al intentar obtener los datos.";

        public static string ErrorNoContent() =>
            "No se pudo encontrar contenido para la solicitud.";

        // Mensajes relacionados con la existencia de elementos
        public static string NotFound() =>
            "El elemento solicitado no fue encontrado.";

        public static string AlreadyExists() =>
            "El elemento ya existe.";

        // Mensajes de validación
        public static string RequiredField(string fieldName) =>
           $"El campo '{fieldName}' es obligatorio.";

        public static string InvalidStringField(string fieldName) =>
            $"El campo '{fieldName}' debe ser una cadena de texto válida.";

        public static string InvalidNumberField(string fieldName) =>
            $"El campo '{fieldName}' debe ser un número válido.";

        public static string InvalidEmailField(string fieldName) =>
            $"El campo '{fieldName}' debe contener una dirección de correo electrónico válida.";

        public static string MinLengthExceeded(string fieldName, int minLength) =>
            $"El campo '{fieldName}' debe tener al menos {minLength} caracteres.";

        public static string MaxLengthExceeded(string fieldName, int maxLength) =>
            $"El campo '{fieldName}' no debe superar los {maxLength} caracteres.";

        public static string ValueOutOfRange(string fieldName, int min, int max) =>
            $"El valor del campo '{fieldName}' debe estar entre {min} y {max}.";

        public static string InvalidFormat(string fieldName) =>
            $"El formato del campo '{fieldName}' no es válido.";

    }
}
