using cmasacoS5B.Model;

namespace cmasacoS5B.Views;

public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        App.PersonRepo.AddNewPerson(txtNombre.Text);
        lblStatus.Text = App.PersonRepo.Status;

    }
    private void btnListar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        List<Persona> people = App.PersonRepo.GetAllPerson();
        ListarPersonas.ItemsSource = people;
    }
}