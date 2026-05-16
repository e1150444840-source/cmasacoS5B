using cmasacoS5B.Model;

namespace cmasacoS5B.Views;

public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
	}

    //BOTEN CREAR
    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        App.PersonRepo.AddNewPerson(txtNombre.Text);
        btnListar_Clicked(null, null);
        lblStatus.Text = App.PersonRepo.Status;
        txtNombre.Text = string.Empty;

        

    }

    //BOTON LISTAR
    private void btnListar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        List<Persona> people = App.PersonRepo.GetAllPerson();
        ListarPersonas.ItemsSource = people;
    }

    //BOTON ELIMINAR
    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var persona = (Persona)button.BindingContext;

        if (persona != null)
        {
            App.PersonRepo.EliminarPerson(persona);
            btnListar_Clicked(null, null);
            lblStatus.Text = App.PersonRepo.Status;
            
        }

    }

    //BONTO ACTUALIZAR 
    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        var botonActualizar = (Button)sender;
        var gridContenedor = (Grid)botonActualizar.Parent;
        var txtNombreFila = (Entry)gridContenedor.FindByName("txtNombreFila");
        var persona = (Persona)botonActualizar.BindingContext;

        if (persona != null && txtNombreFila != null)
        {
            if (botonActualizar.Text == "Actualizar")
            {
                txtNombreFila.IsEnabled = true;
                botonActualizar.Text = "Guardar";
                botonActualizar.BackgroundColor = Microsoft.Maui.Graphics.Color.FromArgb("#2ECC71");
            }
            else if (botonActualizar.Text == "Guardar")
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(txtNombreFila.Text))
                    {
                        throw new Exception("El nombre es Requerido");
                    }

                    persona.Nombre = txtNombreFila.Text;
                    App.PersonRepo.ActualizarPerson(persona);

                    txtNombreFila.IsEnabled = false;
                    botonActualizar.Text = "Editar";
                    botonActualizar.BackgroundColor = Microsoft.Maui.Graphics.Color.FromArgb("#F39C12"); // Naranja

                    btnListar_Clicked(null, null);
                    lblStatus.Text = App.PersonRepo.Status;
                }
                catch (Exception ex)
                {
                    lblStatus.Text = $"Error al actualizar: {ex.Message}";

                }
            }


        }
    }
}
