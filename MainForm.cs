using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace MicroondasDigital
{
    public partial class MainForm : Form
    {
        private string placeholderTempo = "Tempo (segundos)";
        private string placeholderPotencia = "Potência (1-10)";
        private string placeholderNome = "Nome do Programa";
        private string placeholderAlimento = "Alimento";
        private string placeholderCadPotencia = "Potência (1-10)";
        private string placeholderCaractere = "Cadastre Caractere";
        private string placeholderCadTempo = "Tempo (segundos)";
        private string placeholderInstrucoesII = "Instruções (opcional)";
        private bool aquecendo = false;
        private int tempoRestante = 0;
        private int potencia = 10;
        private Timer timerAquecimento;
        private StringBuilder stringAquecimento;
        private Dictionary<string, ProgramaAquecimento> programas;
        private List<CadastrarProgramaAquecimento> programasExistentes;
        private ConexaoDB repositorio;


        public MainForm()
        {
            InitializeComponent();
            cmbProgramas.DropDownStyle = ComboBoxStyle.DropDownList;
            DefinirPlaceholders();
            InicializarTimer();
            InicializarProgramas(); // Isso já vai carregar os programas personalizados
            stringAquecimento = new StringBuilder();
            programasExistentes = new List<CadastrarProgramaAquecimento>();
            repositorio = new ConexaoDB(); // Certifique-se de que esta linha está correta
        }

        private void CarregarProgramasCustomizados()
        {
            var programas = repositorio.ObterTodosProgramas();
            foreach (var programa in programas)
            {
                cmbProgramas.Items.Add(programa.Nome);
                programasExistentes.Add(new CadastrarProgramaAquecimento(programa.Nome, programa.Alimento, programa.CadPotencia, programa.Caractere, programa.CadTempo, programa.InstrucoesII));
            }
        }

        public MainForm(string placeholderInstrucoesII)
        {
            this.placeholderInstrucoesII = placeholderInstrucoesII;
        }


        private void DefinirPlaceholders()
        {
            txtTempo.Text = placeholderTempo;
            txtTempo.ForeColor = SystemColors.GrayText;
            txtTempo.GotFocus += RemoverPlaceholderTempo;
            txtTempo.LostFocus += MostrarPlaceholderTempo;

            txtPotencia.Text = placeholderPotencia;
            txtPotencia.ForeColor = SystemColors.GrayText;
            txtPotencia.GotFocus += RemoverPlaceholderPotencia;
            txtPotencia.LostFocus += MostrarPlaceholderPotencia;

            txtNome.Text = placeholderNome;
            txtNome.ForeColor = SystemColors.GrayText;
            txtNome.GotFocus += RemoverPlaceholderNome;
            txtNome.LostFocus += MostrarPlaceholderNome;

            txtAlimento.Text = placeholderAlimento;
            txtAlimento.ForeColor = SystemColors.GrayText;
            txtAlimento.GotFocus += RemoverPlaceholderAlimento;
            txtAlimento.LostFocus += MostrarPlaceholderAlimento;

            txtCadPotencia.Text = placeholderCadPotencia;
            txtCadPotencia.ForeColor = SystemColors.GrayText;
            txtCadPotencia.GotFocus += RemoverPlaceholderCadPotencia;
            txtCadPotencia.LostFocus += MostrarPlaceholderCadPotencia;

            txtCadTempo.Text = placeholderCadTempo;
            txtCadTempo.ForeColor = SystemColors.GrayText;
            txtCadTempo.GotFocus += RemoverPlaceholderCadTempo;
            txtCadTempo.LostFocus += MostrarPlaceholderCadTempo;

            txtInstrucoesII.Text = placeholderInstrucoesII;
            txtInstrucoesII.ForeColor = SystemColors.GrayText;
            txtInstrucoesII.GotFocus += RemoverPlaceholderInstrucoesII;
            txtInstrucoesII.LostFocus += MostrarPlaceholderInstrucoesII;

            txtCaractere.Text = placeholderCaractere;
            txtCaractere.ForeColor = SystemColors.GrayText;
            txtCaractere.GotFocus += RemoverPlaceholderCaractere;
            txtCaractere.LostFocus += MostrarPlaceholderCaractere;

        }

        private void RemoverPlaceholderTempo(object sender, EventArgs e)
        {
            if (txtTempo.Text == placeholderTempo)
            {
                txtTempo.Text = "";
                txtTempo.ForeColor = SystemColors.WindowText;
            }
        }

        private void MostrarPlaceholderTempo(object sender, EventArgs e)
        {

        }

        private void RemoverPlaceholderPotencia(object sender, EventArgs e)
        {
            if (txtPotencia.Text == placeholderPotencia)
            {
                txtPotencia.Text = "";
                txtPotencia.ForeColor = SystemColors.WindowText;
            }
        }

        private void MostrarPlaceholderPotencia(object sender, EventArgs e)
        {

        }
        private void RemoverPlaceholderNome(object sender, EventArgs e)
        {
            if (txtNome.Text == placeholderNome)
            {
                txtNome.Text = "";
                txtNome.ForeColor = SystemColors.WindowText;
            }
        }

        private void MostrarPlaceholderNome(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                txtNome.Text = placeholderNome;
                txtNome.ForeColor = SystemColors.GrayText;
            }
        }

        // txtAlimento
        private void RemoverPlaceholderAlimento(object sender, EventArgs e)
        {
            if (txtAlimento.Text == placeholderAlimento)
            {
                txtAlimento.Text = "";
                txtAlimento.ForeColor = SystemColors.WindowText;
            }
        }

        private void MostrarPlaceholderAlimento(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAlimento.Text))
            {
                txtAlimento.Text = placeholderAlimento;
                txtAlimento.ForeColor = SystemColors.GrayText;
            }
        }

        // txtCadPotencia
        private void RemoverPlaceholderCadPotencia(object sender, EventArgs e)
        {
            if (txtCadPotencia.Text == placeholderPotencia)
            {
                txtCadPotencia.Text = "";
                txtCadPotencia.ForeColor = SystemColors.WindowText;
            }
        }

        private void MostrarPlaceholderCadPotencia(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCadPotencia.Text))
            {
                txtCadPotencia.Text = placeholderPotencia;
                txtCadPotencia.ForeColor = SystemColors.GrayText;
            }
        }


        // txtCadTempo
        private void RemoverPlaceholderCadTempo(object sender, EventArgs e)
        {
            if (txtCadTempo.Text == placeholderTempo)
            {
                txtCadTempo.Text = "";
                txtCadTempo.ForeColor = SystemColors.WindowText;
            }
        }

        private void MostrarPlaceholderCadTempo(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCadTempo.Text)) // Corrigido para verificar se está vazio
            {
                txtCadTempo.Text = placeholderCadTempo; // Usar placeholderCadTempo em vez de placeholderTempo
                txtCadTempo.ForeColor = SystemColors.GrayText;
            }
        }

        private void RemoverPlaceholderInstrucoesII(object sender, EventArgs e)
        {
            if (txtInstrucoesII.Text == placeholderInstrucoesII)
            {
                txtInstrucoesII.Text = "";
                txtInstrucoesII.ForeColor = SystemColors.WindowText; // Cor padrão do texto
            }
        }

        private void MostrarPlaceholderCaractere(object sender, EventArgs e)
        {
            // Verifica se o TextBox está vazio ou se contém apenas espaços em branco
            if (string.IsNullOrWhiteSpace(txtCaractere.Text))
            {
                txtCaractere.Text = placeholderCaractere; // Certifique-se de que placeholdertxtCaractere esteja definido
                txtCaractere.ForeColor = SystemColors.GrayText; // Cor de placeholder
            }
        }

        private void RemoverPlaceholderCaractere(object sender, EventArgs e)
        {
            // Verifica se o texto no TextBox é o placeholder
            if (txtCaractere.Text == placeholderCaractere)
            {
                txtCaractere.Text = ""; // Remove o placeholder
                txtCaractere.ForeColor = SystemColors.WindowText; // Retorna para a cor padrão de texto
            }
        }


        // Eventos para restaurar o placeholder quando o TextBox perde foco
        private void MostrarPlaceholderInstrucoesII(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInstrucoesII.Text))
            {
                txtInstrucoesII.Text = placeholderInstrucoesII;
                txtInstrucoesII.ForeColor = SystemColors.GrayText; // Cor de placeholder
            }
        }

        private void InicializarTimer()
        {
            timerAquecimento = new Timer();
            timerAquecimento.Interval = 1000; // 1 segundo
            timerAquecimento.Tick += TimerAquecimento_Tick;
        }

        private void TimerAquecimento_Tick(object sender, EventArgs e)
        {
            if (tempoRestante > 0)
            {
                tempoRestante--;

                // Exibe o tempo em minutos e segundos
                if (tempoRestante > 60)
                {
                    int minutos = tempoRestante / 60;
                    int segundos = tempoRestante % 60;
                    lblResultado.Text = $"Aquecendo... {minutos}:{segundos:D2} minutos restantes\n{stringAquecimento.ToString()}";
                }
                else
                {
                    lblResultado.Text = $"Aquecendo... {tempoRestante} segundos restantes\n{stringAquecimento.ToString()}";
                }
            }
            else
            {
                timerAquecimento.Stop();
                aquecendo = false;
                lblResultado.Text = $"Aquecimento concluído!\n{stringAquecimento.ToString()}";
                stringAquecimento.Clear(); // Limpa a string de aquecimento
            }
        }


        private void AtualizarStringAquecimento()
        {
            // Adiciona caracteres à string informativa com base na potência
            for (int i = 0; i < potencia; i++)
            {
                stringAquecimento.Append(".");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int tempo;
            string programaSelecionado = cmbProgramas.SelectedItem?.ToString();

            if (aquecendo && !timerAquecimento.Enabled) // Retoma aquecimento se estiver pausado
            {
                timerAquecimento.Start();
                lblResultado.Text = $"Aquecendo... {tempoRestante} segundos restantes\n{stringAquecimento.ToString()}";
                return;
            }

            if (aquecendo)
            {
                // Verifica se o programa atual é pré-definido
                if (cmbProgramas.SelectedIndex != -1)
                {
                    lblResultado.Text = "Não é permitido o acréscimo de tempo para programas pré-definidos.";
                    return;
                }

                // Caso não seja um programa pré-definido, permite o acréscimo de 30 segundos
                tempoRestante += 30;
                txtTempo.Text = tempoRestante.ToString();
                lblResultado.Text = $"Aquecimento já em andamento. Acrescentando 30 segundos. {tempoRestante} segundos restantes.\n{stringAquecimento.ToString()}";

                // Recalcula a string de aquecimento com o novo tempo
                stringAquecimento.Clear();
                for (int i = 0; i < tempoRestante; i++)
                {
                    for (int j = 0; j < potencia; j++)
                    {
                        string caractere = (programaSelecionado != null && programas.TryGetValue(programaSelecionado, out ProgramaAquecimento programa))
                                           ? programa.Caractere : ".";
                        stringAquecimento.Append(caractere);
                    }
                    if (i < tempoRestante - 1)
                    {
                        stringAquecimento.Append(" ");
                    }
                }

                lblResultado.Text = stringAquecimento.ToString();
                return;
            }
            else
            {
                // Se o programa selecionado for "Feijão", aplica configurações fixas
                if (programaSelecionado == "Feijão")
                {
                    tempo = 150;
                    potencia = 6;
                }
                else
                {
                    // 🔹 Se nenhum tempo for informado, aplica o "Início Rápido" (30s)
                    if (string.IsNullOrWhiteSpace(txtTempo.Text) || txtTempo.Text == placeholderTempo)
                    {
                        tempo = 30;
                        txtTempo.Text = "30";
                        txtTempo.ForeColor = Color.Lime;

                    }
                    else if (!int.TryParse(txtTempo.Text, out tempo) || tempo < 1 || tempo > 120)
                    {
                        MessageBox.Show("Por favor, insira um tempo válido em segundos (1-120).");
                        return;
                    }

                    // 🔹 Se nenhuma potência for informada, aplica 10 como padrão
                    if (string.IsNullOrWhiteSpace(txtPotencia.Text) || txtPotencia.Text == placeholderPotencia)
                    {
                        potencia = 10;
                        txtPotencia.Text = "10";
                        txtPotencia.ForeColor = Color.Lime;
                    }
                    else if (!int.TryParse(txtPotencia.Text, out potencia) || potencia < 1 || potencia > 10)
                    {
                        MessageBox.Show("Por favor, insira uma potência válida (1-10).");
                        return;
                    }
                }
            }

            aquecendo = true;
            tempoRestante = tempo;

            // 🔹 Atualiza a string de aquecimento baseada no tempo e potência
            stringAquecimento.Clear();
            for (int i = 0; i < tempo; i++)
            {
                for (int j = 0; j < potencia; j++)
                {
                    string caractere = (programaSelecionado != null && programas.TryGetValue(programaSelecionado, out ProgramaAquecimento programa))
                                       ? programa.Caractere : ".";
                    stringAquecimento.Append(caractere);
                }
                if (i < tempo - 1)
                {
                    stringAquecimento.Append(" ");
                }
            }

            lblResultado.Text = stringAquecimento.ToString();
            timerAquecimento.Start();
        }

        private void btnPauseCancel_Click(object sender, EventArgs e)
        {
            if (aquecendo)
            {
                if (timerAquecimento.Enabled)
                {
                    // Se o aquecimento estiver em andamento, pausa o aquecimento
                    timerAquecimento.Stop();
                    lblResultado.Text = "Aquecimento pausado.";
                }
                else
                {
                    // Se o aquecimento estiver pausado, cancela o aquecimento
                    aquecendo = false;
                    tempoRestante = 0;
                    lblResultado.Text = "Aquecimento cancelado.";
                    // Limpa os campos de tempo e potência
                    txtTempo.Clear();
                    txtPotencia.Clear();
                    // Deseleciona o programa e limpa as instruções
                    cmbProgramas.SelectedIndex = -1;
                    txtInstrucoes.Clear();
                    // Reabilita os campos
                    txtTempo.Enabled = true;
                    txtPotencia.Enabled = true;
                }
            }
            else
            {
                // Se o aquecimento não foi iniciado, limpa as informações de tempo e potência
                lblResultado.Text = "Aquecimento cancelado.";
                txtTempo.Clear();
                txtPotencia.Clear();
                // Deseleciona o programa e limpa as instruções
                cmbProgramas.SelectedIndex = -1;
                txtInstrucoes.Clear();
                // Reabilita os campos
                txtTempo.Enabled = true;
                txtPotencia.Enabled = true;
            }
        }

        private void InicializarProgramas()
        {
            // Inicialize o repositorio se não foi feito antes
            if (repositorio == null)
            {
                repositorio = new ConexaoDB();
            }

            programas = new Dictionary<string, ProgramaAquecimento>
    {
        { "Pipoca", new ProgramaAquecimento("Pipoca", 120, 7, "Observar o barulho de estouros do milho. Caso haja intervalo de mais de 10 segundos entre um estouro e outro, interrompa o aquecimento.","@") },
        { "Leite", new ProgramaAquecimento("Leite", 120, 5, "Cuidado com o aquecimento de líquidos. O choque térmico pode causar fervura imediata e risco de queimaduras.", "#") },
        { "Carne de Boi", new ProgramaAquecimento("Carne de Boi", 120, 4, "Interrompa o aquecimento na metade e vire a carne para um aquecimento uniforme.", "$") },
        { "Frango", new ProgramaAquecimento("Frango", 120, 7, "Interrompa na metade e vire o frango para garantir o aquecimento uniforme.", "%") },
        { "Feijão", new ProgramaAquecimento("Feijão", 120, 9, "Deixe o recipiente destampado. Tenha cuidado ao retirar o recipiente, pois pode estar muito quente.", "&") },
    };

            // Preenche o ComboBox com os programas pré-definidos
            cmbProgramas.Items.AddRange(programas.Keys.ToArray());

            // Carregar os programas customizados do banco e adicionar ao ComboBox
            var programasCustomizados = repositorio.ObterTodosProgramas();
            foreach (var programa in programasCustomizados)
            {
                cmbProgramas.Items.Add(programa.Nome); // Adiciona os programas customizados ao ComboBox
            }

            cmbProgramas.SelectedIndexChanged += cmbProgramas_SelectedIndexChanged;
        }


        private void cmbProgramas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProgramas.SelectedIndex != -1)
            {
                string programaSelecionado = cmbProgramas.SelectedItem.ToString();

                // Verifica se o programa é um pré-definido
                if (programas.ContainsKey(programaSelecionado))
                {
                    // Carrega os dados do programa pré-definido
                    ProgramaAquecimento programa = programas[programaSelecionado];
                    txtTempo.Text = programa.Tempo.ToString();
                    txtPotencia.Text = programa.Potencia.ToString();
                    txtInstrucoes.Text = programa.Instrucoes;
                    txtTempo.Enabled = false; // Desabilita o campo de tempo
                    txtPotencia.Enabled = false; // Desabilita o campo de potência
                    txtTempo.ForeColor = Color.Lime;
                    txtPotencia.ForeColor = Color.Lime;
                }
                else
                {
                    // Carrega os dados do programa customizado
                    var programaCustomizado = repositorio.ObterTodosProgramas()
                        .FirstOrDefault(p => p.Nome == programaSelecionado);

                    if (programaCustomizado != null)
                    {
                        // Preenche os campos com os dados do programa customizado
                        txtTempo.Text = programaCustomizado.CadTempo.ToString();
                        txtPotencia.Text = programaCustomizado.CadPotencia.ToString();
                        txtInstrucoes.Text = programaCustomizado.InstrucoesII;
                        txtTempo.Enabled = true;  // Habilita o campo de tempo
                        txtPotencia.Enabled = true;  // Habilita o campo de potência
                        txtTempo.ForeColor = Color.Lime;
                        txtPotencia.ForeColor = Color.Lime;
                    }
                }
            }
        }


        public class ProgramaAquecimento
        {
            public string Nome { get; }
            public int Tempo { get; }
            public int Potencia { get; }
            public string Instrucoes { get; }
            public string Caractere { get; }

            public ProgramaAquecimento(string nome, int tempo, int potencia, string instrucoes, string caractere)
            {
                Nome = nome;
                Tempo = tempo;
                Potencia = potencia;
                Instrucoes = instrucoes;
                Caractere = caractere;
            }
        }

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Captura os valores dos TextBox
                string nome = txtNome.Text.Trim();
                string alimento = txtAlimento.Text.Trim();
                int cadPotencia = int.TryParse(txtCadPotencia.Text.Trim(), out cadPotencia) ? cadPotencia : 0;
                int cadTempo = int.TryParse(txtCadTempo.Text.Trim(), out cadTempo) ? cadTempo : 0;
                string instrucoesII = txtInstrucoesII.Text.Trim();
                string caractere = txtCaractere.Text.Trim();

                // Validação de campos obrigatórios
                if (string.IsNullOrWhiteSpace(nome) ||
                    string.IsNullOrWhiteSpace(alimento) ||
                    string.IsNullOrWhiteSpace(caractere) ||
                    cadPotencia < 1 || cadPotencia > 10 ||
                    cadTempo < 1 || cadTempo > 120)
                {
                    MessageBox.Show("Por favor, preencha todos os campos corretamente. Potência deve estar entre 1 e 10 e tempo entre 1 e 120 segundos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verifica se o caractere é válido
                if (caractere == ".")
                {
                    MessageBox.Show("O caractere de aquecimento não pode ser '.'.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cria uma instância do programa de aquecimento
                var novoPrograma = new CadastrarProgramaAquecimento(nome, alimento, cadPotencia, caractere, cadTempo, instrucoesII);

                // Valida o programa
                novoPrograma.Validar(programasExistentes);

                MessageBox.Show("Programa cadastrado com sucesso!");

                // Salva o programa no banco de dados
                repositorio.SalvarProgramaCustomizado(nome, alimento, cadPotencia, caractere, cadTempo, instrucoesII, cmbProgramas);

                // Limpa os campos de texto após o cadastro
                txtNome.Clear();
                txtAlimento.Clear();
                txtCadPotencia.Clear();
                txtCadTempo.Clear();
                txtCaractere.Clear();
                txtInstrucoesII.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BotaoNumero_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button; // Converte o objeto sender para um botão

            if (btn != null)
            {
                if (txtTempo.Text.Length < 3) // Impede que ultrapasse 3 dígitos (máx. 120 segundos)
                {
                    txtTempo.Text += btn.Text;
                }
                txtTempo.ForeColor = Color.Lime;
            }
        }

        private void txtTempo_Click(object sender, EventArgs e)
        {
            txtTempo.Focus(); // Garante que o campo recebe foco ao clicar
        }

        private void txtPotencia_Click(object sender, EventArgs e)
        {
            txtPotencia.Focus();
        }
    }
}