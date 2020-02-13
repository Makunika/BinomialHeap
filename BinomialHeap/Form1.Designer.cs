namespace BinomialHeap
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openTextFile = new System.Windows.Forms.Button();
            this.labelHeap = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openTextFile
            // 
            this.openTextFile.Location = new System.Drawing.Point(62, 360);
            this.openTextFile.Name = "openTextFile";
            this.openTextFile.Size = new System.Drawing.Size(139, 45);
            this.openTextFile.TabIndex = 0;
            this.openTextFile.Text = "Открыть текстовый файл";
            this.openTextFile.UseVisualStyleBackColor = true;
            this.openTextFile.Click += new System.EventHandler(this.openTextFile_Click);
            // 
            // labelHeap
            // 
            this.labelHeap.AutoSize = true;
            this.labelHeap.Location = new System.Drawing.Point(62, 36);
            this.labelHeap.Name = "labelHeap";
            this.labelHeap.Size = new System.Drawing.Size(101, 13);
            this.labelHeap.TabIndex = 1;
            this.labelHeap.Text = "тектовый вид кучи";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelHeap);
            this.Controls.Add(this.openTextFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openTextFile;
        private System.Windows.Forms.Label labelHeap;
    }
}

