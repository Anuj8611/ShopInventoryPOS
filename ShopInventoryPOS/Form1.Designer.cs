
using System.Windows.Forms;

namespace ShopInventoryPOS
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowProducts;
        private System.Windows.Forms.Panel panelCart;
        private System.Windows.Forms.Label labelCartTitle;
        private System.Windows.Forms.ListBox listBoxCart;
        private System.Windows.Forms.Label labelTotalTitle;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCheckout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flowProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCart = new System.Windows.Forms.Panel();
            this.labelCartTitle = new System.Windows.Forms.Label();
            this.listBoxCart = new System.Windows.Forms.ListBox();
            this.labelTotalTitle = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.panelCart.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowProducts
            // 
            this.flowProducts.AutoScroll = true;
            this.flowProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowProducts.Location = new System.Drawing.Point(0, 0);
            this.flowProducts.Name = "flowProducts";
            this.flowProducts.Size = new System.Drawing.Size(520, 450);
            this.flowProducts.TabIndex = 0;
            // 
            // panelCart
            // 
            this.panelCart.Controls.Add(this.labelCartTitle);
            this.panelCart.Controls.Add(this.listBoxCart);
            this.panelCart.Controls.Add(this.labelTotalTitle);
            this.panelCart.Controls.Add(this.labelTotal);
            this.panelCart.Controls.Add(this.btnClear);
            this.panelCart.Controls.Add(this.btnCheckout);
            this.panelCart.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelCart.Location = new System.Drawing.Point(520, 0);
            this.panelCart.Name = "panelCart";
            this.panelCart.Size = new System.Drawing.Size(280, 450);
            this.panelCart.TabIndex = 1;
            // 
            // labelCartTitle
            // 
            this.labelCartTitle.AutoSize = true;
            this.labelCartTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelCartTitle.Location = new System.Drawing.Point(15, 10);
            this.labelCartTitle.Name = "labelCartTitle";
            this.labelCartTitle.Size = new System.Drawing.Size(42, 21);
            this.labelCartTitle.TabIndex = 0;
            this.labelCartTitle.Text = "Cart";
            // 
            // listBoxCart
            // 
            this.listBoxCart.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.listBoxCart.FormattingEnabled = true;
            this.listBoxCart.ItemHeight = 15;
            this.listBoxCart.Location = new System.Drawing.Point(15, 40);
            this.listBoxCart.Name = "listBoxCart";
            this.listBoxCart.Size = new System.Drawing.Size(250, 184);
            this.listBoxCart.TabIndex = 1;
            // 
            // labelTotalTitle
            // 
            this.labelTotalTitle.AutoSize = true;
            this.labelTotalTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelTotalTitle.Location = new System.Drawing.Point(15, 240);
            this.labelTotalTitle.Name = "labelTotalTitle";
            this.labelTotalTitle.Size = new System.Drawing.Size(44, 19);
            this.labelTotalTitle.TabIndex = 2;
            this.labelTotalTitle.Text = "Total:";
            // 
            // labelTotal
            // 
            this.labelTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelTotal.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelTotal.Location = new System.Drawing.Point(220, 240);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(29, 19);
            this.labelTotal.TabIndex = 3;
            this.labelTotal.Text = "₹0";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnClear.Location = new System.Drawing.Point(15, 400);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCheckout
            // 
            this.btnCheckout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnCheckout.Location = new System.Drawing.Point(165, 400);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(100, 30);
            this.btnCheckout.TabIndex = 5;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowProducts);
            this.Controls.Add(this.panelCart);
            this.Name = "Form1";
            this.Text = "Shop Inventory POS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelCart.ResumeLayout(false);
            this.panelCart.PerformLayout();
            this.ResumeLayout(false);
        }

    }
}
