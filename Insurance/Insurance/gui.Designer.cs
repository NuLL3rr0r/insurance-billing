namespace Insurance
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripMenuItem tbXPOliveSkin;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.ToolStripMenuItem tbXPMetallicSkin;
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mItemInsurance = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemTaminEjtemaei = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemKhadamaatDarmaaniNMJA = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemKhadamaatDarmaani = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemInsuranceSep01 = new System.Windows.Forms.ToolStripSeparator();
            this.mItemInsurancePercent = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemInsuranceSep02 = new System.Windows.Forms.ToolStripSeparator();
            this.mItemInsurancePrintInfoTe = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemInsurancePrintInfoKDNMJA = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemInsurancePrintInfoKD = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemErase = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemFileSep01 = new System.Windows.Forms.ToolStripSeparator();
            this.mItemDefDocName = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemDefTreatmentArea = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemFileSep02 = new System.Windows.Forms.ToolStripSeparator();
            this.mItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemReports = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemReportsByMonth = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemReportsFreeDate = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemPrefrences = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemStyles = new System.Windows.Forms.ToolStripMenuItem();
            this.tbXPBlueSkin = new System.Windows.Forms.ToolStripMenuItem();
            this.tbXPRoyaleSKin = new System.Windows.Forms.ToolStripMenuItem();
            this.tbOfficeBlueSkin = new System.Windows.Forms.ToolStripMenuItem();
            this.tbOfficeBlackSkin = new System.Windows.Forms.ToolStripMenuItem();
            this.tbVistaAeroSkin = new System.Windows.Forms.ToolStripMenuItem();
            this.tbOSXAquaSkin = new System.Windows.Forms.ToolStripMenuItem();
            this.tbOSXBrushedSkin = new System.Windows.Forms.ToolStripMenuItem();
            this.tbOSXMetallic = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemChangePw = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemProtect = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.osSkin1 = new SkinSoft.OSSkin.OSSkin(this.components);
            this.tblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvMaster = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            tbXPOliveSkin = new System.Windows.Forms.ToolStripMenuItem();
            tbXPMetallicSkin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.osSkin1)).BeginInit();
            this.tblLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // tbXPOliveSkin
            // 
            tbXPOliveSkin.BackColor = System.Drawing.Color.White;
            tbXPOliveSkin.Image = ((System.Drawing.Image)(resources.GetObject("tbXPOliveSkin.Image")));
            tbXPOliveSkin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            tbXPOliveSkin.Name = "tbXPOliveSkin";
            tbXPOliveSkin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            tbXPOliveSkin.Size = new System.Drawing.Size(310, 36);
            tbXPOliveSkin.Tag = "XPOLIVE";
            tbXPOliveSkin.Text = "XP Olive";
            tbXPOliveSkin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            tbXPOliveSkin.Click += new System.EventHandler(this.tbSkin_Clicked);
            // 
            // tbXPMetallicSkin
            // 
            tbXPMetallicSkin.BackColor = System.Drawing.Color.White;
            tbXPMetallicSkin.Image = ((System.Drawing.Image)(resources.GetObject("tbXPMetallicSkin.Image")));
            tbXPMetallicSkin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            tbXPMetallicSkin.Name = "tbXPMetallicSkin";
            tbXPMetallicSkin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            tbXPMetallicSkin.Size = new System.Drawing.Size(310, 36);
            tbXPMetallicSkin.Tag = "XPSILVER";
            tbXPMetallicSkin.Text = "XP Metallic";
            tbXPMetallicSkin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            tbXPMetallicSkin.Click += new System.EventHandler(this.tbSkin_Clicked);
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemInsurance,
            this.mItemFile,
            this.mItemSearch,
            this.mItemReports,
            this.mItemBackup,
            this.mItemPrefrences,
            this.mItemProtect,
            this.mItemAbout});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1016, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mItemInsurance
            // 
            this.mItemInsurance.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemTaminEjtemaei,
            this.mItemKhadamaatDarmaaniNMJA,
            this.mItemKhadamaatDarmaani,
            this.mItemInsuranceSep01,
            this.mItemInsurancePercent,
            this.mItemInsuranceSep02,
            this.mItemInsurancePrintInfoTe,
            this.mItemInsurancePrintInfoKDNMJA,
            this.mItemInsurancePrintInfoKD});
            this.mItemInsurance.Name = "mItemInsurance";
            this.mItemInsurance.Size = new System.Drawing.Size(57, 20);
            this.mItemInsurance.Tag = "نوع بیمه";
            this.mItemInsurance.Text = "نوع بیمه";
            // 
            // mItemTaminEjtemaei
            // 
            this.mItemTaminEjtemaei.Name = "mItemTaminEjtemaei";
            this.mItemTaminEjtemaei.Size = new System.Drawing.Size(241, 22);
            this.mItemTaminEjtemaei.Tag = "";
            this.mItemTaminEjtemaei.Text = "تامین اجتماعی";
            this.mItemTaminEjtemaei.Click += new System.EventHandler(this.mItemTaminEjtemaei_Click);
            // 
            // mItemKhadamaatDarmaaniNMJA
            // 
            this.mItemKhadamaatDarmaaniNMJA.Name = "mItemKhadamaatDarmaaniNMJA";
            this.mItemKhadamaatDarmaaniNMJA.Size = new System.Drawing.Size(241, 22);
            this.mItemKhadamaatDarmaaniNMJA.Text = "خدمات درمانی ن م جا";
            this.mItemKhadamaatDarmaaniNMJA.Click += new System.EventHandler(this.mItemKhadamaatDarmaaniNMJA_Click);
            // 
            // mItemKhadamaatDarmaani
            // 
            this.mItemKhadamaatDarmaani.Name = "mItemKhadamaatDarmaani";
            this.mItemKhadamaatDarmaani.Size = new System.Drawing.Size(241, 22);
            this.mItemKhadamaatDarmaani.Text = "خدمات درمانی";
            this.mItemKhadamaatDarmaani.Click += new System.EventHandler(this.mItemKhadamaatDarmaani_Click);
            // 
            // mItemInsuranceSep01
            // 
            this.mItemInsuranceSep01.Name = "mItemInsuranceSep01";
            this.mItemInsuranceSep01.Size = new System.Drawing.Size(238, 6);
            // 
            // mItemInsurancePercent
            // 
            this.mItemInsurancePercent.Name = "mItemInsurancePercent";
            this.mItemInsurancePercent.Size = new System.Drawing.Size(241, 22);
            this.mItemInsurancePercent.Text = "تعیین درصد بیمه";
            this.mItemInsurancePercent.Click += new System.EventHandler(this.mItemInsurancePercent_Click);
            // 
            // mItemInsuranceSep02
            // 
            this.mItemInsuranceSep02.Name = "mItemInsuranceSep02";
            this.mItemInsuranceSep02.Size = new System.Drawing.Size(238, 6);
            // 
            // mItemInsurancePrintInfoTe
            // 
            this.mItemInsurancePrintInfoTe.Name = "mItemInsurancePrintInfoTe";
            this.mItemInsurancePrintInfoTe.Size = new System.Drawing.Size(241, 22);
            this.mItemInsurancePrintInfoTe.Text = "تعیین اطلاعات تامین اجتماعی";
            this.mItemInsurancePrintInfoTe.Click += new System.EventHandler(this.mItemInsurancePrintInfoTe_Click);
            // 
            // mItemInsurancePrintInfoKDNMJA
            // 
            this.mItemInsurancePrintInfoKDNMJA.Name = "mItemInsurancePrintInfoKDNMJA";
            this.mItemInsurancePrintInfoKDNMJA.Size = new System.Drawing.Size(241, 22);
            this.mItemInsurancePrintInfoKDNMJA.Text = "تعیین اطلاعات خدمات درمانی ن م جا";
            this.mItemInsurancePrintInfoKDNMJA.Click += new System.EventHandler(this.mItemInsurancePrintInfoKDNMJA_Click);
            // 
            // mItemInsurancePrintInfoKD
            // 
            this.mItemInsurancePrintInfoKD.Name = "mItemInsurancePrintInfoKD";
            this.mItemInsurancePrintInfoKD.Size = new System.Drawing.Size(241, 22);
            this.mItemInsurancePrintInfoKD.Text = "تعیین اطلاعات خدمات درمانی";
            this.mItemInsurancePrintInfoKD.Click += new System.EventHandler(this.mItemInsurancePrintInfoKD_Click);
            // 
            // mItemFile
            // 
            this.mItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemNew,
            this.mItemEdit,
            this.mItemErase,
            this.mItemFileSep01,
            this.mItemDefDocName,
            this.mItemDefTreatmentArea,
            this.mItemFileSep02,
            this.mItemExit});
            this.mItemFile.Name = "mItemFile";
            this.mItemFile.Size = new System.Drawing.Size(46, 20);
            this.mItemFile.Text = "پرونده";
            // 
            // mItemNew
            // 
            this.mItemNew.Enabled = false;
            this.mItemNew.Name = "mItemNew";
            this.mItemNew.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mItemNew.Size = new System.Drawing.Size(161, 22);
            this.mItemNew.Text = "جدید";
            this.mItemNew.Click += new System.EventHandler(this.mItemNew_Click);
            // 
            // mItemEdit
            // 
            this.mItemEdit.Enabled = false;
            this.mItemEdit.Name = "mItemEdit";
            this.mItemEdit.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.mItemEdit.Size = new System.Drawing.Size(161, 22);
            this.mItemEdit.Text = "ویرایش";
            this.mItemEdit.Click += new System.EventHandler(this.mItemEdit_Click);
            // 
            // mItemErase
            // 
            this.mItemErase.Enabled = false;
            this.mItemErase.Name = "mItemErase";
            this.mItemErase.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.mItemErase.Size = new System.Drawing.Size(161, 22);
            this.mItemErase.Text = "حذف";
            this.mItemErase.Click += new System.EventHandler(this.mItemErase_Click);
            // 
            // mItemFileSep01
            // 
            this.mItemFileSep01.Name = "mItemFileSep01";
            this.mItemFileSep01.Size = new System.Drawing.Size(158, 6);
            // 
            // mItemDefDocName
            // 
            this.mItemDefDocName.Name = "mItemDefDocName";
            this.mItemDefDocName.Size = new System.Drawing.Size(161, 22);
            this.mItemDefDocName.Text = "تعریف نام پزشک";
            this.mItemDefDocName.Click += new System.EventHandler(this.mItemDefDocName_Click);
            // 
            // mItemDefTreatmentArea
            // 
            this.mItemDefTreatmentArea.Name = "mItemDefTreatmentArea";
            this.mItemDefTreatmentArea.Size = new System.Drawing.Size(161, 22);
            this.mItemDefTreatmentArea.Text = "تعریف نواحی درمان";
            this.mItemDefTreatmentArea.Click += new System.EventHandler(this.mItemDefTreatmentArea_Click);
            // 
            // mItemFileSep02
            // 
            this.mItemFileSep02.Name = "mItemFileSep02";
            this.mItemFileSep02.Size = new System.Drawing.Size(158, 6);
            // 
            // mItemExit
            // 
            this.mItemExit.Name = "mItemExit";
            this.mItemExit.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.mItemExit.Size = new System.Drawing.Size(161, 22);
            this.mItemExit.Text = "خروج";
            this.mItemExit.Click += new System.EventHandler(this.mItemExit_Click);
            // 
            // mItemSearch
            // 
            this.mItemSearch.Enabled = false;
            this.mItemSearch.Name = "mItemSearch";
            this.mItemSearch.Size = new System.Drawing.Size(54, 20);
            this.mItemSearch.Tag = "جستجو";
            this.mItemSearch.Text = "جستجو";
            // 
            // mItemReports
            // 
            this.mItemReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemReportsByMonth,
            this.mItemReportsFreeDate});
            this.mItemReports.Enabled = false;
            this.mItemReports.Name = "mItemReports";
            this.mItemReports.Size = new System.Drawing.Size(59, 20);
            this.mItemReports.Text = "گزارشات";
            // 
            // mItemReportsByMonth
            // 
            this.mItemReportsByMonth.Name = "mItemReportsByMonth";
            this.mItemReportsByMonth.Size = new System.Drawing.Size(122, 22);
            this.mItemReportsByMonth.Text = "یک ماهه";
            this.mItemReportsByMonth.Click += new System.EventHandler(this.mItemReports_Click);
            // 
            // mItemReportsFreeDate
            // 
            this.mItemReportsFreeDate.Name = "mItemReportsFreeDate";
            this.mItemReportsFreeDate.Size = new System.Drawing.Size(122, 22);
            this.mItemReportsFreeDate.Text = "تاریخ معین";
            this.mItemReportsFreeDate.Click += new System.EventHandler(this.mItemReportsFreeDate_Click);
            // 
            // mItemBackup
            // 
            this.mItemBackup.Name = "mItemBackup";
            this.mItemBackup.Size = new System.Drawing.Size(118, 20);
            this.mItemBackup.Text = "تهیه / بازیابی پشتیبان";
            this.mItemBackup.Click += new System.EventHandler(this.mItemBackup_Click);
            // 
            // mItemPrefrences
            // 
            this.mItemPrefrences.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemStyles,
            this.mItemChangePw});
            this.mItemPrefrences.Name = "mItemPrefrences";
            this.mItemPrefrences.Size = new System.Drawing.Size(57, 20);
            this.mItemPrefrences.Text = "تنظیمات";
            // 
            // mItemStyles
            // 
            this.mItemStyles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbXPBlueSkin,
            tbXPOliveSkin,
            tbXPMetallicSkin,
            this.tbXPRoyaleSKin,
            this.tbOfficeBlueSkin,
            this.tbOfficeBlackSkin,
            this.tbVistaAeroSkin,
            this.tbOSXAquaSkin,
            this.tbOSXBrushedSkin,
            this.tbOSXMetallic});
            this.mItemStyles.Name = "mItemStyles";
            this.mItemStyles.Size = new System.Drawing.Size(163, 22);
            this.mItemStyles.Text = "سبک و ظاهر";
            // 
            // tbXPBlueSkin
            // 
            this.tbXPBlueSkin.BackColor = System.Drawing.Color.White;
            this.tbXPBlueSkin.Image = ((System.Drawing.Image)(resources.GetObject("tbXPBlueSkin.Image")));
            this.tbXPBlueSkin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbXPBlueSkin.Name = "tbXPBlueSkin";
            this.tbXPBlueSkin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbXPBlueSkin.ShowShortcutKeys = false;
            this.tbXPBlueSkin.Size = new System.Drawing.Size(310, 36);
            this.tbXPBlueSkin.Tag = "XPBLUE";
            this.tbXPBlueSkin.Text = "XP Blue";
            this.tbXPBlueSkin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbXPBlueSkin.Click += new System.EventHandler(this.tbSkin_Clicked);
            // 
            // tbXPRoyaleSKin
            // 
            this.tbXPRoyaleSKin.BackColor = System.Drawing.Color.White;
            this.tbXPRoyaleSKin.Image = ((System.Drawing.Image)(resources.GetObject("tbXPRoyaleSKin.Image")));
            this.tbXPRoyaleSKin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbXPRoyaleSKin.Name = "tbXPRoyaleSKin";
            this.tbXPRoyaleSKin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbXPRoyaleSKin.Size = new System.Drawing.Size(310, 36);
            this.tbXPRoyaleSKin.Tag = "XPROYALE";
            this.tbXPRoyaleSKin.Text = "XP Royale";
            this.tbXPRoyaleSKin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbXPRoyaleSKin.Click += new System.EventHandler(this.tbSkin_Clicked);
            // 
            // tbOfficeBlueSkin
            // 
            this.tbOfficeBlueSkin.BackColor = System.Drawing.Color.White;
            this.tbOfficeBlueSkin.Image = ((System.Drawing.Image)(resources.GetObject("tbOfficeBlueSkin.Image")));
            this.tbOfficeBlueSkin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbOfficeBlueSkin.Name = "tbOfficeBlueSkin";
            this.tbOfficeBlueSkin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbOfficeBlueSkin.Size = new System.Drawing.Size(310, 36);
            this.tbOfficeBlueSkin.Tag = "OFFICEBLUE";
            this.tbOfficeBlueSkin.Text = "Office 2007 Blue";
            this.tbOfficeBlueSkin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbOfficeBlueSkin.Click += new System.EventHandler(this.tbSkin_Clicked);
            // 
            // tbOfficeBlackSkin
            // 
            this.tbOfficeBlackSkin.BackColor = System.Drawing.Color.White;
            this.tbOfficeBlackSkin.Image = ((System.Drawing.Image)(resources.GetObject("tbOfficeBlackSkin.Image")));
            this.tbOfficeBlackSkin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbOfficeBlackSkin.Name = "tbOfficeBlackSkin";
            this.tbOfficeBlackSkin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbOfficeBlackSkin.Size = new System.Drawing.Size(310, 36);
            this.tbOfficeBlackSkin.Tag = "OFFICEBLACK";
            this.tbOfficeBlackSkin.Text = "Office 2007 Black";
            this.tbOfficeBlackSkin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbOfficeBlackSkin.Click += new System.EventHandler(this.tbSkin_Clicked);
            // 
            // tbVistaAeroSkin
            // 
            this.tbVistaAeroSkin.BackColor = System.Drawing.Color.White;
            this.tbVistaAeroSkin.Image = ((System.Drawing.Image)(resources.GetObject("tbVistaAeroSkin.Image")));
            this.tbVistaAeroSkin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbVistaAeroSkin.Name = "tbVistaAeroSkin";
            this.tbVistaAeroSkin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbVistaAeroSkin.Size = new System.Drawing.Size(310, 36);
            this.tbVistaAeroSkin.Tag = "VISTAAERO";
            this.tbVistaAeroSkin.Text = "Vista Aero Classic";
            this.tbVistaAeroSkin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbVistaAeroSkin.Click += new System.EventHandler(this.tbSkin_Clicked);
            // 
            // tbOSXAquaSkin
            // 
            this.tbOSXAquaSkin.BackColor = System.Drawing.Color.White;
            this.tbOSXAquaSkin.Image = ((System.Drawing.Image)(resources.GetObject("tbOSXAquaSkin.Image")));
            this.tbOSXAquaSkin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbOSXAquaSkin.Name = "tbOSXAquaSkin";
            this.tbOSXAquaSkin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbOSXAquaSkin.Size = new System.Drawing.Size(310, 36);
            this.tbOSXAquaSkin.Tag = "OSXAQUA";
            this.tbOSXAquaSkin.Text = "OSX Aqua";
            this.tbOSXAquaSkin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbOSXAquaSkin.Click += new System.EventHandler(this.tbSkin_Clicked);
            // 
            // tbOSXBrushedSkin
            // 
            this.tbOSXBrushedSkin.BackColor = System.Drawing.Color.White;
            this.tbOSXBrushedSkin.Image = ((System.Drawing.Image)(resources.GetObject("tbOSXBrushedSkin.Image")));
            this.tbOSXBrushedSkin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbOSXBrushedSkin.Name = "tbOSXBrushedSkin";
            this.tbOSXBrushedSkin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbOSXBrushedSkin.Size = new System.Drawing.Size(310, 36);
            this.tbOSXBrushedSkin.Tag = "OSXBRUSHED";
            this.tbOSXBrushedSkin.Text = "OSX Brushed";
            this.tbOSXBrushedSkin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbOSXBrushedSkin.Click += new System.EventHandler(this.tbSkin_Clicked);
            // 
            // tbOSXMetallic
            // 
            this.tbOSXMetallic.BackColor = System.Drawing.Color.White;
            this.tbOSXMetallic.Image = ((System.Drawing.Image)(resources.GetObject("tbOSXMetallic.Image")));
            this.tbOSXMetallic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbOSXMetallic.Name = "tbOSXMetallic";
            this.tbOSXMetallic.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbOSXMetallic.Size = new System.Drawing.Size(310, 36);
            this.tbOSXMetallic.Tag = "OSXSILVER";
            this.tbOSXMetallic.Text = "OSX Metallic";
            this.tbOSXMetallic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbOSXMetallic.Click += new System.EventHandler(this.tbSkin_Clicked);
            // 
            // mItemChangePw
            // 
            this.mItemChangePw.Name = "mItemChangePw";
            this.mItemChangePw.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mItemChangePw.Size = new System.Drawing.Size(163, 22);
            this.mItemChangePw.Text = "تغییر کلمه عبور";
            this.mItemChangePw.Click += new System.EventHandler(this.mItemChangePw_Click);
            // 
            // mItemProtect
            // 
            this.mItemProtect.Name = "mItemProtect";
            this.mItemProtect.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.mItemProtect.Size = new System.Drawing.Size(136, 20);
            this.mItemProtect.Text = "محافظت با کلمه عبور   F9";
            this.mItemProtect.Click += new System.EventHandler(this.mItemProtect_Click);
            // 
            // mItemAbout
            // 
            this.mItemAbout.Name = "mItemAbout";
            this.mItemAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mItemAbout.Size = new System.Drawing.Size(64, 20);
            this.mItemAbout.Text = "درباره   F1";
            this.mItemAbout.Click += new System.EventHandler(this.mItemAbout_Click);
            // 
            // osSkin1
            // 
            this.osSkin1.Style = SkinSoft.OSSkin.SkinStyle.Office2007Black;
            // 
            // tblLayout
            // 
            this.tblLayout.ColumnCount = 1;
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.Controls.Add(this.txtSearch, 0, 0);
            this.tblLayout.Controls.Add(this.dgvMaster, 0, 1);
            this.tblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayout.Location = new System.Drawing.Point(0, 24);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.RowCount = 2;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.Size = new System.Drawing.Size(1016, 710);
            this.tblLayout.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Enabled = false;
            this.txtSearch.Location = new System.Drawing.Point(3, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(1010, 21);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtSearch_PreviewKeyDown);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // dgvMaster
            // 
            this.dgvMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaster.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dgvMaster.Location = new System.Drawing.Point(3, 27);
            this.dgvMaster.Name = "dgvMaster";
            this.dgvMaster.ReadOnly = true;
            this.dgvMaster.Size = new System.Drawing.Size(1010, 680);
            this.dgvMaster.TabIndex = 2;
            this.dgvMaster.CurrentCellChanged += new System.EventHandler(this.dgvMaster_CurrentCellChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 99;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.tblLayout);
            this.Controls.Add(this.mnuMain);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نرم افزار بیمه";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.osSkin1)).EndInit();
            this.tblLayout.ResumeLayout(false);
            this.tblLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mItemPrefrences;
        private System.Windows.Forms.ToolStripMenuItem mItemStyles;
        private System.Windows.Forms.ToolStripMenuItem tbXPBlueSkin;
        private System.Windows.Forms.ToolStripMenuItem tbXPRoyaleSKin;
        private System.Windows.Forms.ToolStripMenuItem tbOfficeBlueSkin;
        private System.Windows.Forms.ToolStripMenuItem tbOfficeBlackSkin;
        private System.Windows.Forms.ToolStripMenuItem tbVistaAeroSkin;
        private System.Windows.Forms.ToolStripMenuItem tbOSXAquaSkin;
        private System.Windows.Forms.ToolStripMenuItem tbOSXBrushedSkin;
        private System.Windows.Forms.ToolStripMenuItem tbOSXMetallic;
        private System.Windows.Forms.ToolStripMenuItem mItemAbout;
        private System.Windows.Forms.ToolStripMenuItem mItemFile;
        private System.Windows.Forms.ToolStripMenuItem mItemNew;
        private System.Windows.Forms.ToolStripMenuItem mItemEdit;
        private System.Windows.Forms.ToolStripMenuItem mItemErase;
        private System.Windows.Forms.ToolStripSeparator mItemFileSep01;
        private System.Windows.Forms.ToolStripMenuItem mItemExit;
        private System.Windows.Forms.ToolStripMenuItem mItemChangePw;
        private System.Windows.Forms.ToolStripMenuItem mItemSearch;
        private System.Windows.Forms.ToolStripMenuItem mItemInsurance;
        private System.Windows.Forms.ToolStripMenuItem mItemTaminEjtemaei;
        private System.Windows.Forms.ToolStripMenuItem mItemKhadamaatDarmaaniNMJA;
        private System.Windows.Forms.ToolStripMenuItem mItemReports;
        private SkinSoft.OSSkin.OSSkin osSkin1;
        private System.Windows.Forms.ToolStripMenuItem mItemBackup;
        private System.Windows.Forms.ToolStripMenuItem mItemProtect;
        private System.Windows.Forms.TableLayoutPanel tblLayout;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvMaster;
        private System.Windows.Forms.ToolStripSeparator mItemInsuranceSep01;
        private System.Windows.Forms.ToolStripMenuItem mItemInsurancePercent;
        private System.Windows.Forms.ToolStripMenuItem mItemKhadamaatDarmaani;
        private System.Windows.Forms.ToolStripSeparator mItemFileSep02;
        private System.Windows.Forms.ToolStripMenuItem mItemDefDocName;
        private System.Windows.Forms.ToolStripMenuItem mItemDefTreatmentArea;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem mItemInsurancePrintInfoTe;
        private System.Windows.Forms.ToolStripMenuItem mItemInsurancePrintInfoKDNMJA;
        private System.Windows.Forms.ToolStripMenuItem mItemInsurancePrintInfoKD;
        private System.Windows.Forms.ToolStripSeparator mItemInsuranceSep02;
        private System.Windows.Forms.ToolStripMenuItem mItemReportsByMonth;
        private System.Windows.Forms.ToolStripMenuItem mItemReportsFreeDate;
    }
}