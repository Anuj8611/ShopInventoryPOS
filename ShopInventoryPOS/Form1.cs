using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Drawing.Printing;

namespace ShopInventoryPOS
{
    public partial class Form1 : Form
    {
        private List<Product> products = new List<Product>();
        private Dictionary<int, int> cart = new Dictionary<int, int>();

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            flowProducts.Controls.Clear();
            listBoxCart.Items.Clear();
            labelTotal.Text = "₹0";
            cart.Clear();

            string jsonPath = "products.json";
            if (!File.Exists(jsonPath))
            {
                MessageBox.Show("products.json not found!");
                return;
            }

            string json = File.ReadAllText(jsonPath);
            products = JsonConvert.DeserializeObject<List<Product>>(json);

            foreach (var p in products)
            {
                if (File.Exists(p.ImagePath))
                {
                    Panel card = CreateProductCard(p);
                    flowProducts.Controls.Add(card);
                }
            }
        }

        private Panel CreateProductCard(Product p)
        {
            Panel card = new Panel
            {
                Width = 150,
                Height = 200,
                Margin = new Padding(10),
                BackColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle
            };

            PictureBox pic = new PictureBox
            {
                Image = Image.FromFile(p.ImagePath),
                SizeMode = PictureBoxSizeMode.Zoom,
                Width = 120,
                Height = 100,
                Location = new Point(15, 10)
            };

            Label lblName = new Label
            {
                Text = p.Name,
                Width = 120,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(15, pic.Bottom + 5)
            };

            Label lblPrice = new Label
            {
                Text = $"₹{p.Price}",
                Width = 120,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(15, lblName.Bottom + 5)
            };

            Button btnAdd = new Button
            {
                Text = "Add to Cart",
                Width = 120,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(15, lblPrice.Bottom + 5)
            };

            btnAdd.Click += (s, e) => AddToCart(p.Id);

            card.Controls.Add(pic);
            card.Controls.Add(lblName);
            card.Controls.Add(lblPrice);
            card.Controls.Add(btnAdd);

            return card;
        }

        private void AddToCart(int productId)
        {
            if (cart.ContainsKey(productId))
                cart[productId]++;
            else
                cart[productId] = 1;

            RefreshCart();
        }

        private void RefreshCart()
        {
            listBoxCart.Items.Clear();
            double total = 0;

            foreach (var kvp in cart)
            {
                var product = products.Find(p => p.Id == kvp.Key);
                int qty = kvp.Value;
                double itemTotal = qty * product.Price;
                total += itemTotal;
                listBoxCart.Items.Add($"{qty}x {product.Name} – ₹{itemTotal}");
            }

            labelTotal.Text = $"₹{total}";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cart.Clear();
            RefreshCart();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Cart is empty!");
                return;
            }

            PrintDocument pd = new PrintDocument();
            PaperSize thermalSize = new PaperSize("A6", 413, 583);
            pd.DefaultPageSettings.PaperSize = thermalSize;
            pd.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10); // optional small margins

            pd.PrintPage += new PrintPageEventHandler(PrintReceipt);

            PrintDialog dlg = new PrintDialog
            {
                Document = pd
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }

            MessageBox.Show("Checkout complete!\nTotal: " + labelTotal.Text);
            cart.Clear();
            RefreshCart();

        }

        private void PrintReceipt(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float x = 10;
            float y = 10;
            float width = e.MarginBounds.Width;

            Font headerFont = new Font("DotMatrix", 12, FontStyle.Bold);
            Font itemFont = new Font("DotMatrix", 9);
            Font boldFont = new Font("DotMatrix", 9, FontStyle.Bold);
            float lineHeight = itemFont.GetHeight(g) + 4;

            // Centered shop heading
            string shopTitle = "MY LOCAL STORE";
            SizeF titleSize = g.MeasureString(shopTitle, headerFont);
            g.DrawString(shopTitle, headerFont, Brushes.Black, (width - titleSize.Width) / 2, y);
            y += lineHeight * 2;

            // Column headers
            g.DrawString("Item", boldFont, Brushes.Black, x, y);
            g.DrawString("Qty", boldFont, Brushes.Black, x + 130, y);
            g.DrawString("Price", boldFont, Brushes.Black, x + 170, y);
            g.DrawString("Total", boldFont, Brushes.Black, x + 230, y);
            y += lineHeight;

            g.DrawLine(Pens.Black, x, y, x + 300, y);
            y += 4;

            double totalAmount = 0;

            foreach (var kvp in cart)
            {
                var product = products.Find(p => p.Id == kvp.Key);
                int qty = kvp.Value;
                double unitPrice = product.Price;
                double itemTotal = unitPrice * qty;
                totalAmount += itemTotal;

                g.DrawString(product.Name, itemFont, Brushes.Black, x, y);
                g.DrawString(qty.ToString(), itemFont, Brushes.Black, x + 130, y);
                g.DrawString($"₹{unitPrice:F2}", itemFont, Brushes.Black, x + 170, y);
                g.DrawString($"₹{itemTotal:F2}", itemFont, Brushes.Black, x + 230, y);

                y += lineHeight;
            }

            y += lineHeight;

            // Total (right aligned)
            string totalLine = $"Total: ₹{totalAmount:F2}";
            SizeF totalSize = g.MeasureString(totalLine, boldFont);
            g.DrawString(totalLine, boldFont, Brushes.Black, x + 230 - totalSize.Width + 70, y);
        }


    }


}

public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string ImagePath { get; set; }
    }
