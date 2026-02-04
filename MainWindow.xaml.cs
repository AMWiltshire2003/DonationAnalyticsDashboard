using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace DonationAnalyticsDashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string connectionString =
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DonationAnalyticsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public MainWindow()
        {
            InitializeComponent();
            LoadDonations();
            LoadCategorySummary();
            LoadStatusKpis();
        }

        private void LoadDonations(DateTime? fromDate = null, DateTime? toDate = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                string query = "SELECT * FROM Donations WHERE 1=1";

                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                if (fromDate.HasValue)
                {
                    query += " AND DonationDate >= @FromDate";
                    command.Parameters.AddWithValue("@FromDate", fromDate.Value);
                }

                if (toDate.HasValue)
                {
                    query += " AND DonationDate <= @ToDate";
                    command.Parameters.AddWithValue("@ToDate", toDate.Value);
                }

                command.CommandText = query;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                DonationsGrid.ItemsSource = table.DefaultView;
            }
        }


        private void LoadCategorySummary(DateTime? fromDate = null, DateTime? toDate = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT Category, SUM(Quantity) AS TotalQuantity
            FROM Donations
            WHERE 1=1";

                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                if (fromDate.HasValue)
                {
                    query += " AND DonationDate >= @FromDate";
                    command.Parameters.AddWithValue("@FromDate", fromDate.Value);
                }

                if (toDate.HasValue)
                {
                    query += " AND DonationDate <= @ToDate";
                    command.Parameters.AddWithValue("@ToDate", toDate.Value);
                }

                query += " GROUP BY Category";
                command.CommandText = query;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                CategorySummaryGrid.ItemsSource = table.DefaultView;
            }
        }

        private void LoadStatusKpis(DateTime? fromDate = null, DateTime? toDate = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT
                SUM(CASE WHEN Status = 'Pending' THEN Quantity ELSE 0 END) AS PendingTotal,
                SUM(CASE WHEN Status = 'Distributed' THEN Quantity ELSE 0 END) AS DistributedTotal
            FROM Donations
            WHERE 1=1";

                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                if (fromDate.HasValue)
                {
                    query += " AND DonationDate >= @FromDate";
                    command.Parameters.AddWithValue("@FromDate", fromDate.Value);
                }

                if (toDate.HasValue)
                {
                    query += " AND DonationDate <= @ToDate";
                    command.Parameters.AddWithValue("@ToDate", toDate.Value);
                }

                command.CommandText = query;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    PendingText.Text = reader["PendingTotal"]?.ToString() ?? "0";
                    DistributedText.Text = reader["DistributedTotal"]?.ToString() ?? "0";
                }
            }
        }

        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            DateTime? fromDate = FromDatePicker.SelectedDate;
            DateTime? toDate = ToDatePicker.SelectedDate;

            LoadDonations(fromDate, toDate);
            LoadCategorySummary(fromDate, toDate);
            LoadStatusKpis(fromDate, toDate);
        }

    }
}