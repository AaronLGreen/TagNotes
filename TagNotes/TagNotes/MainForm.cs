using System;
using System.Drawing;
using System.Windows.Forms;

namespace TagNotes
{
    public partial class MainForm : Form
    {
        private string connectionString = @"Server=TagNotesDev\SQLEXPRESS;Initial Catalog=TagNoteDB;User ID=TagNoteAdmin;Password=P@$$W0rd1234567;";



        public MainForm()
        {
            InitializeComponent();
            contentTextBox.Enter += ContentTextBox_Enter;
            contentTextBox.Leave += ContentTextBox_Leave;
            tagsTextBox.Enter += TagsTextBox_Enter;
            tagsTextBox.Leave += TagsTextBox_Leave;
            searchTextBox.Enter += SearchTextBox_Enter;
            searchTextBox.Leave += SearchTextBox_Leave;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Removed LoadNotes() to keep notesListView empty initially
        }

        private void LoadNotes()
        {
            NoteRepository noteRepository = new NoteRepository(connectionString);
            var notes = noteRepository.GetAllNotes();

            notesListView.Items.Clear();
            foreach (var note in notes)
            {
                if (!string.IsNullOrEmpty(note.Content))
                {
                    var item = new ListViewItem(note.Content);
                    item.SubItems.Add(note.Tags);
                    item.Tag = note.Id;
                    notesListView.Items.Add(item);
                }
            }
        }

        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            string content = contentTextBox.Text;
            string tags = tagsTextBox.Text;

            NoteRepository noteRepository = new NoteRepository(connectionString);
            noteRepository.AddNote(new Note { Content = content, Tags = tags });

            // Removed LoadNotes() to prevent automatically loading notes
            statusLabel.Text = "Note added successfully!";
        }

        private void UpdateNoteButton_Click(object sender, EventArgs e)
        {
            if (notesListView.SelectedItems.Count > 0)
            {
                var selectedItem = notesListView.SelectedItems[0];
                string content = contentTextBox.Text;
                string tags = tagsTextBox.Text;
                int noteId = int.Parse(selectedItem.Tag.ToString());

                NoteRepository noteRepository = new NoteRepository(connectionString);
                noteRepository.UpdateNote(new Note { Id = noteId, Content = content, Tags = tags });

                LoadNotes();
                statusLabel.Text = "Note updated successfully!";
            }
            else
            {
                statusLabel.Text = "Select a note to update.";
            }
        }

        private void DeleteNoteButton_Click(object sender, EventArgs e)
        {
            if (notesListView.SelectedItems.Count > 0)
            {
                var selectedItem = notesListView.SelectedItems[0];
                int noteId = int.Parse(selectedItem.Tag.ToString());

                NoteRepository noteRepository = new NoteRepository(connectionString);
                noteRepository.DeleteNote(noteId);

                LoadNotes();
                statusLabel.Text = "Note deleted successfully!";
            }
            else
            {
                statusLabel.Text = "Select a note to delete.";
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchQuery = searchTextBox.Text.Trim();

            if (string.IsNullOrEmpty(searchQuery) || searchQuery.Equals("Search notes...", StringComparison.OrdinalIgnoreCase))
            {
                statusLabel.Text = "Please enter a search term.";
                return;
            }

            NoteRepository noteRepository = new NoteRepository(connectionString);
            var notes = noteRepository.SearchNotes(searchQuery);

            notesListView.Items.Clear();

            if (notes.Count == 0)
            {
                statusLabel.Text = "No notes found.";
                return;
            }

            foreach (var note in notes)
            {
                if (!string.IsNullOrEmpty(note.Content))
                {
                    var item = new ListViewItem(note.Content);
                    item.SubItems.Add(note.Tags);
                    item.Tag = note.Id;
                    notesListView.Items.Add(item);
                }
            }

            statusLabel.Text = $"{notes.Count} note(s) found.";
        }

        private void ContentTextBox_Enter(object sender, EventArgs e)
        {
            if (contentTextBox.Text == "Enter note content...")
            {
                contentTextBox.Text = "";
                contentTextBox.ForeColor = SystemColors.ControlText;
            }
        }

        private void ContentTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(contentTextBox.Text))
            {
                contentTextBox.Text = "Enter note content...";
                contentTextBox.ForeColor = Color.Gray;
            }
        }

        private void TagsTextBox_Enter(object sender, EventArgs e)
        {
            if (tagsTextBox.Text == "Enter tags (comma-separated)")
            {
                tagsTextBox.Text = "";
                tagsTextBox.ForeColor = SystemColors.ControlText;
            }
        }

        private void TagsTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tagsTextBox.Text))
            {
                tagsTextBox.Text = "Enter tags (comma-separated)";
                tagsTextBox.ForeColor = Color.Gray;
            }
        }

        private void SearchTextBox_Enter(object sender, EventArgs e)
        {
            if (searchTextBox.Text == "Search notes...")
            {
                searchTextBox.Text = "";
                searchTextBox.ForeColor = SystemColors.ControlText;
            }
        }

        private void SearchTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                searchTextBox.Text = "Search notes...";
                searchTextBox.ForeColor = Color.Gray;
            }
        }

        private void notesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
