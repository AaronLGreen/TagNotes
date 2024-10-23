namespace TagNotes
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

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
            contentTextBox = new TextBox();
            tagsTextBox = new TextBox();
            addNoteButton = new Button();
            searchButton = new Button();
            updateNoteButton = new Button();
            deleteNoteButton = new Button();
            notesListView = new ListView();
            searchTextBox = new TextBox();
            statusLabel = new Label();
            SuspendLayout();
            contentTextBox.BackColor = Color.White;
            contentTextBox.ForeColor = Color.Gray;
            contentTextBox.Location = new Point(12, 12);
            contentTextBox.Multiline = true;
            contentTextBox.Name = "contentTextBox";
            contentTextBox.Size = new Size(360, 150);
            contentTextBox.TabIndex = 0;
            contentTextBox.Text = "Enter note content...";
            tagsTextBox.ForeColor = Color.Gray;
            tagsTextBox.Location = new Point(12, 168);
            tagsTextBox.Name = "tagsTextBox";
            tagsTextBox.Size = new Size(360, 23);
            tagsTextBox.TabIndex = 1;
            tagsTextBox.Text = "Enter tags (comma-separated)";
            addNoteButton.Location = new Point(12, 194);
            addNoteButton.Name = "addNoteButton";
            addNoteButton.Size = new Size(75, 23);
            addNoteButton.TabIndex = 2;
            addNoteButton.Text = "Add Note";
            addNoteButton.UseVisualStyleBackColor = true;
            addNoteButton.Click += AddNoteButton_Click;
            searchButton.Location = new Point(12, 249);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(75, 23);
            searchButton.TabIndex = 4;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += SearchButton_Click;
            updateNoteButton.Location = new Point(93, 194);
            updateNoteButton.Name = "updateNoteButton";
            updateNoteButton.Size = new Size(75, 23);
            updateNoteButton.TabIndex = 5;
            updateNoteButton.Text = "Update Note";
            updateNoteButton.UseVisualStyleBackColor = true;
            updateNoteButton.Click += UpdateNoteButton_Click;
            deleteNoteButton.BackColor = Color.Black;
            deleteNoteButton.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            deleteNoteButton.FlatAppearance.BorderSize = 3;
            deleteNoteButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            deleteNoteButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            deleteNoteButton.FlatStyle = FlatStyle.Popup;
            deleteNoteButton.ForeColor = Color.PaleGoldenrod;
            deleteNoteButton.Location = new Point(174, 194);
            deleteNoteButton.Name = "deleteNoteButton";
            deleteNoteButton.Size = new Size(75, 23);
            deleteNoteButton.TabIndex = 6;
            deleteNoteButton.Text = "Delete Note";
            deleteNoteButton.UseVisualStyleBackColor = false;
            deleteNoteButton.Click += DeleteNoteButton_Click;
            notesListView.BackColor = Color.White;
            notesListView.ForeColor = Color.Black;
            notesListView.FullRowSelect = true;
            notesListView.Location = new Point(12, 278);
            notesListView.Name = "notesListView";
            notesListView.Size = new Size(360, 130);
            notesListView.TabIndex = 7;
            notesListView.UseCompatibleStateImageBehavior = false;
            notesListView.View = View.List;
            notesListView.SelectedIndexChanged += notesListView_SelectedIndexChanged;
            searchTextBox.ForeColor = Color.Gray;
            searchTextBox.Location = new Point(12, 223);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(360, 23);
            searchTextBox.TabIndex = 3;
            searchTextBox.Text = "Search notes...";
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(17, 436);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(0, 15);
            statusLabel.TabIndex = 8;
            AutoScrollMargin = new Size(5, 5);
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.DarkKhaki;
            ClientSize = new Size(450, 526);
            Controls.Add(statusLabel);
            Controls.Add(notesListView);
            Controls.Add(deleteNoteButton);
            Controls.Add(updateNoteButton);
            Controls.Add(searchButton);
            Controls.Add(searchTextBox);
            Controls.Add(addNoteButton);
            Controls.Add(tagsTextBox);
            Controls.Add(contentTextBox);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ForeColor = Color.Black;
            Name = "MainForm";
            Padding = new Padding(5);
            Text = "TagNote";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox contentTextBox;
        private System.Windows.Forms.TextBox tagsTextBox;
        private System.Windows.Forms.Button addNoteButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button updateNoteButton;
        private System.Windows.Forms.Button deleteNoteButton;
        private System.Windows.Forms.ListView notesListView;
        private System.Windows.Forms.TextBox searchTextBox;
        private Label statusLabel;
    }
}
