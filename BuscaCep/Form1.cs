namespace BuscaCep
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
        
                string cep = txtCEP.Text.Trim();

                if (!string.IsNullOrEmpty(cep))
                {
                    try
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            string url = $"https://viacep.com.br/ws/{cep}/json/";
                            HttpResponseMessage response = await client.GetAsync(url);

                            if (response.IsSuccessStatusCode)
                            {
                                string xmlResponse = await response.Content.ReadAsStringAsync();
                                // Aqui você pode processar o xmlResponse e exibir as informações no Label
                                lblResultado.Text = xmlResponse;
                            }
                            else
                            {
                                lblResultado.Text = "Erro ao obter as informações do CEP.";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lblResultado.Text = $"Erro: {ex.Message}";
                    }
                }
                else
                {
                    lblResultado.Text = "Por favor, digite um CEP válido.";
                }
            }
        }
    }
