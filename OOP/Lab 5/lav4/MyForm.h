#pragma once
#include "Figure.h"
#include "Composite.h"
#include "Square.h"
#include "Rhombus.h"
#include "Triangle.h"
#include "Circle.h"
#include "Controller.h"
#include "Scrambler.h"
#include <string>

namespace lav4 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	public ref class MyForm : public System::Windows::Forms::Form
	{
	public:
		Graphics^ g;
		Controller^ controller;
	private: int check = 0;
	private: System::Windows::Forms::Timer^ timer1;
	private: System::Windows::Forms::Button^ button2;
	private: System::Windows::Forms::GroupBox^ groupBox1;
	private: System::Windows::Forms::RadioButton^ rbTailed2;
	private: System::Windows::Forms::RadioButton^ rbTailed1;
	private: System::Windows::Forms::Button^ btnStopTimer;
	private: System::Windows::Forms::Button^ btnRefresh;
	private: System::Windows::Forms::GroupBox^ groupBox2;
	private: System::Windows::Forms::CheckBox^ checkBox4;
	private: System::Windows::Forms::CheckBox^ checkBox3;
	private: System::Windows::Forms::CheckBox^ checkBox2;
	private: System::Windows::Forms::CheckBox^ checkBox1;
	private: System::Windows::Forms::ComboBox^ comboBox1;
	private: System::Windows::Forms::GroupBox^ groupBox3;
	private: System::Windows::Forms::Button^ button4;
	private: System::Windows::Forms::ComboBox^ comboBox2;
	private: System::Windows::Forms::GroupBox^ groupBox4;
	private: System::Windows::Forms::RadioButton^ rbtInvisible;
	private: System::Windows::Forms::RadioButton^ rbtVisible;
	private: System::Windows::Forms::Button^ button3;
	private: System::Windows::Forms::Button^ btnDelete;
	private: System::Windows::Forms::Button^ btnChangeShape;
	private: System::Windows::Forms::GroupBox^ groupBox5;


	private: System::Windows::Forms::Button^ btnSave;
	private: System::Windows::Forms::Button^ btnUpload;

	public:
		int addIteration;
		MyForm(void)
		{
			InitializeComponent();
			g = pictureBox1->CreateGraphics();
			controller = Controller::GetInstance(pictureBox1->CreateGraphics());

		}

	protected:
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::PictureBox^ pictureBox1;
	protected:
	private: System::Windows::Forms::Button^ button1;
	private: System::ComponentModel::IContainer^ components;

	private:


#pragma region Windows Form Designer generated code
		void InitializeComponent(void)
		{
			this->components = (gcnew System::ComponentModel::Container());
			System::ComponentModel::ComponentResourceManager^ resources = (gcnew System::ComponentModel::ComponentResourceManager(MyForm::typeid));
			this->pictureBox1 = (gcnew System::Windows::Forms::PictureBox());
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->timer1 = (gcnew System::Windows::Forms::Timer(this->components));
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->groupBox1 = (gcnew System::Windows::Forms::GroupBox());
			this->btnStopTimer = (gcnew System::Windows::Forms::Button());
			this->rbTailed2 = (gcnew System::Windows::Forms::RadioButton());
			this->rbTailed1 = (gcnew System::Windows::Forms::RadioButton());
			this->btnRefresh = (gcnew System::Windows::Forms::Button());
			this->groupBox2 = (gcnew System::Windows::Forms::GroupBox());
			this->checkBox4 = (gcnew System::Windows::Forms::CheckBox());
			this->checkBox3 = (gcnew System::Windows::Forms::CheckBox());
			this->checkBox2 = (gcnew System::Windows::Forms::CheckBox());
			this->checkBox1 = (gcnew System::Windows::Forms::CheckBox());
			this->comboBox1 = (gcnew System::Windows::Forms::ComboBox());
			this->groupBox3 = (gcnew System::Windows::Forms::GroupBox());
			this->button4 = (gcnew System::Windows::Forms::Button());
			this->comboBox2 = (gcnew System::Windows::Forms::ComboBox());
			this->groupBox4 = (gcnew System::Windows::Forms::GroupBox());
			this->rbtInvisible = (gcnew System::Windows::Forms::RadioButton());
			this->rbtVisible = (gcnew System::Windows::Forms::RadioButton());
			this->button3 = (gcnew System::Windows::Forms::Button());
			this->btnDelete = (gcnew System::Windows::Forms::Button());
			this->btnChangeShape = (gcnew System::Windows::Forms::Button());
			this->groupBox5 = (gcnew System::Windows::Forms::GroupBox());
			this->btnSave = (gcnew System::Windows::Forms::Button());
			this->btnUpload = (gcnew System::Windows::Forms::Button());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->BeginInit();
			this->groupBox1->SuspendLayout();
			this->groupBox2->SuspendLayout();
			this->groupBox3->SuspendLayout();
			this->groupBox4->SuspendLayout();
			this->groupBox5->SuspendLayout();
			this->SuspendLayout();
			// 
			// pictureBox1
			// 
			this->pictureBox1->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Stretch;
			this->pictureBox1->Location = System::Drawing::Point(13, 6);
			this->pictureBox1->Margin = System::Windows::Forms::Padding(4);
			this->pictureBox1->Name = L"pictureBox1";
			this->pictureBox1->Size = System::Drawing::Size(1067, 615);
			this->pictureBox1->TabIndex = 0;
			this->pictureBox1->TabStop = false;
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(8, 23);
			this->button1->Margin = System::Windows::Forms::Padding(4);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(137, 78);
			this->button1->TabIndex = 1;
			this->button1->Text = L"Добавить фигуру";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &MyForm::button1_Click);
			// 
			// timer1
			// 
			this->timer1->Tick += gcnew System::EventHandler(this, &MyForm::timer1_Tick);
			// 
			// button2
			// 
			this->button2->Location = System::Drawing::Point(12, 52);
			this->button2->Margin = System::Windows::Forms::Padding(4);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(149, 38);
			this->button2->TabIndex = 2;
			this->button2->Text = L"Движение";
			this->button2->UseVisualStyleBackColor = true;
			this->button2->Click += gcnew System::EventHandler(this, &MyForm::button2_Click);
			// 
			// groupBox1
			// 
			this->groupBox1->BackColor = System::Drawing::Color::Transparent;
			this->groupBox1->Controls->Add(this->btnStopTimer);
			this->groupBox1->Controls->Add(this->rbTailed2);
			this->groupBox1->Controls->Add(this->button2);
			this->groupBox1->Controls->Add(this->rbTailed1);
			this->groupBox1->Location = System::Drawing::Point(1113, 355);
			this->groupBox1->Margin = System::Windows::Forms::Padding(4);
			this->groupBox1->Name = L"groupBox1";
			this->groupBox1->Padding = System::Windows::Forms::Padding(4);
			this->groupBox1->Size = System::Drawing::Size(323, 96);
			this->groupBox1->TabIndex = 3;
			this->groupBox1->TabStop = false;
			this->groupBox1->Text = L"Хвост";
			// 
			// btnStopTimer
			// 
			this->btnStopTimer->Location = System::Drawing::Point(161, 52);
			this->btnStopTimer->Margin = System::Windows::Forms::Padding(4);
			this->btnStopTimer->Name = L"btnStopTimer";
			this->btnStopTimer->Size = System::Drawing::Size(153, 38);
			this->btnStopTimer->TabIndex = 3;
			this->btnStopTimer->Text = L"Остановить";
			this->btnStopTimer->UseVisualStyleBackColor = true;
			this->btnStopTimer->Click += gcnew System::EventHandler(this, &MyForm::btnStopTimer_Click);
			// 
			// rbTailed2
			// 
			this->rbTailed2->AutoSize = true;
			this->rbTailed2->Location = System::Drawing::Point(184, 23);
			this->rbTailed2->Margin = System::Windows::Forms::Padding(4);
			this->rbTailed2->Name = L"rbTailed2";
			this->rbTailed2->Size = System::Drawing::Size(103, 21);
			this->rbTailed2->TabIndex = 1;
			this->rbTailed2->Text = L"Выключить";
			this->rbTailed2->UseVisualStyleBackColor = true;
			// 
			// rbTailed1
			// 
			this->rbTailed1->AutoSize = true;
			this->rbTailed1->Checked = true;
			this->rbTailed1->Location = System::Drawing::Point(8, 23);
			this->rbTailed1->Margin = System::Windows::Forms::Padding(4);
			this->rbTailed1->Name = L"rbTailed1";
			this->rbTailed1->Size = System::Drawing::Size(93, 21);
			this->rbTailed1->TabIndex = 0;
			this->rbTailed1->TabStop = true;
			this->rbTailed1->Text = L"Включить";
			this->rbTailed1->UseVisualStyleBackColor = true;
			this->rbTailed1->CheckedChanged += gcnew System::EventHandler(this, &MyForm::rbTailed1_CheckedChanged);
			// 
			// btnRefresh
			// 
			this->btnRefresh->Location = System::Drawing::Point(1340, 459);
			this->btnRefresh->Margin = System::Windows::Forms::Padding(4);
			this->btnRefresh->Name = L"btnRefresh";
			this->btnRefresh->Size = System::Drawing::Size(96, 55);
			this->btnRefresh->TabIndex = 4;
			this->btnRefresh->Text = L"Исходная позиция";
			this->btnRefresh->UseVisualStyleBackColor = true;
			this->btnRefresh->Click += gcnew System::EventHandler(this, &MyForm::btnRefresh_Click);
			// 
			// groupBox2
			// 
			this->groupBox2->BackColor = System::Drawing::Color::Transparent;
			this->groupBox2->Controls->Add(this->checkBox4);
			this->groupBox2->Controls->Add(this->checkBox3);
			this->groupBox2->Controls->Add(this->checkBox2);
			this->groupBox2->Controls->Add(this->checkBox1);
			this->groupBox2->Location = System::Drawing::Point(1113, 128);
			this->groupBox2->Margin = System::Windows::Forms::Padding(4);
			this->groupBox2->Name = L"groupBox2";
			this->groupBox2->Padding = System::Windows::Forms::Padding(4);
			this->groupBox2->Size = System::Drawing::Size(323, 82);
			this->groupBox2->TabIndex = 5;
			this->groupBox2->TabStop = false;
			this->groupBox2->Text = L"Фигуры";
			// 
			// checkBox4
			// 
			this->checkBox4->AutoSize = true;
			this->checkBox4->Location = System::Drawing::Point(127, 52);
			this->checkBox4->Margin = System::Windows::Forms::Padding(4);
			this->checkBox4->Name = L"checkBox4";
			this->checkBox4->Size = System::Drawing::Size(91, 21);
			this->checkBox4->TabIndex = 3;
			this->checkBox4->Text = L"Фигура 4";
			this->checkBox4->UseVisualStyleBackColor = true;
			this->checkBox4->Visible = false;
			this->checkBox4->CheckedChanged += gcnew System::EventHandler(this, &MyForm::checkBox4_CheckedChanged);
			// 
			// checkBox3
			// 
			this->checkBox3->AutoSize = true;
			this->checkBox3->Location = System::Drawing::Point(127, 23);
			this->checkBox3->Margin = System::Windows::Forms::Padding(4);
			this->checkBox3->Name = L"checkBox3";
			this->checkBox3->Size = System::Drawing::Size(91, 21);
			this->checkBox3->TabIndex = 2;
			this->checkBox3->Text = L"Фигура 3";
			this->checkBox3->UseVisualStyleBackColor = true;
			this->checkBox3->Visible = false;
			this->checkBox3->CheckedChanged += gcnew System::EventHandler(this, &MyForm::checkBox3_CheckedChanged);
			// 
			// checkBox2
			// 
			this->checkBox2->AutoSize = true;
			this->checkBox2->Location = System::Drawing::Point(12, 52);
			this->checkBox2->Margin = System::Windows::Forms::Padding(4);
			this->checkBox2->Name = L"checkBox2";
			this->checkBox2->Size = System::Drawing::Size(91, 21);
			this->checkBox2->TabIndex = 1;
			this->checkBox2->Text = L"Фигура 2";
			this->checkBox2->UseVisualStyleBackColor = true;
			this->checkBox2->Visible = false;
			this->checkBox2->CheckedChanged += gcnew System::EventHandler(this, &MyForm::checkBox2_CheckedChanged);
			// 
			// checkBox1
			// 
			this->checkBox1->AutoSize = true;
			this->checkBox1->Location = System::Drawing::Point(12, 23);
			this->checkBox1->Margin = System::Windows::Forms::Padding(4);
			this->checkBox1->Name = L"checkBox1";
			this->checkBox1->Size = System::Drawing::Size(91, 21);
			this->checkBox1->TabIndex = 0;
			this->checkBox1->Text = L"Фигура 1";
			this->checkBox1->UseVisualStyleBackColor = true;
			this->checkBox1->Visible = false;
			this->checkBox1->CheckedChanged += gcnew System::EventHandler(this, &MyForm::checkBox1_CheckedChanged);
			// 
			// comboBox1
			// 
			this->comboBox1->FormattingEnabled = true;
			this->comboBox1->Items->AddRange(gcnew cli::array< System::Object^  >(4) {
				L"Square/Квадрат", L"Triangle/Треугольник", L"Rhombus/Ромб",
					L"Circle/Круг"
			});
			this->comboBox1->Location = System::Drawing::Point(153, 23);
			this->comboBox1->Margin = System::Windows::Forms::Padding(4);
			this->comboBox1->Name = L"comboBox1";
			this->comboBox1->Size = System::Drawing::Size(160, 24);
			this->comboBox1->TabIndex = 6;
			this->comboBox1->Text = L"Square/Квадрат";
			// 
			// groupBox3
			// 
			this->groupBox3->BackColor = System::Drawing::Color::Transparent;
			this->groupBox3->Controls->Add(this->button4);
			this->groupBox3->Controls->Add(this->comboBox2);
			this->groupBox3->Location = System::Drawing::Point(1113, 218);
			this->groupBox3->Margin = System::Windows::Forms::Padding(4);
			this->groupBox3->Name = L"groupBox3";
			this->groupBox3->Padding = System::Windows::Forms::Padding(4);
			this->groupBox3->Size = System::Drawing::Size(323, 66);
			this->groupBox3->TabIndex = 8;
			this->groupBox3->TabStop = false;
			this->groupBox3->Text = L"Цвет";
			// 
			// button4
			// 
			this->button4->Location = System::Drawing::Point(8, 23);
			this->button4->Margin = System::Windows::Forms::Padding(4);
			this->button4->Name = L"button4";
			this->button4->Size = System::Drawing::Size(116, 34);
			this->button4->TabIndex = 1;
			this->button4->Text = L"Изменить";
			this->button4->UseVisualStyleBackColor = true;
			this->button4->Click += gcnew System::EventHandler(this, &MyForm::button4_Click);
			// 
			// comboBox2
			// 
			this->comboBox2->FormattingEnabled = true;
			this->comboBox2->Items->AddRange(gcnew cli::array< System::Object^  >(9) {
				L"Red/Красный", L"Green/Зелёный", L"Pink/Розовый",
					L"Aqua/Голубой", L"Yellow/Жёлтый", L"Black/Чёрный", L"Magenta/Пурпурный", L"Cyan/Морская волна", L" Blue/Синий"
			});
			this->comboBox2->Location = System::Drawing::Point(140, 23);
			this->comboBox2->Margin = System::Windows::Forms::Padding(4);
			this->comboBox2->Name = L"comboBox2";
			this->comboBox2->Size = System::Drawing::Size(160, 24);
			this->comboBox2->TabIndex = 0;
			this->comboBox2->Text = L"Red";
			// 
			// groupBox4
			// 
			this->groupBox4->BackColor = System::Drawing::Color::Transparent;
			this->groupBox4->Controls->Add(this->rbtInvisible);
			this->groupBox4->Controls->Add(this->rbtVisible);
			this->groupBox4->Location = System::Drawing::Point(1113, 292);
			this->groupBox4->Margin = System::Windows::Forms::Padding(4);
			this->groupBox4->Name = L"groupBox4";
			this->groupBox4->Padding = System::Windows::Forms::Padding(4);
			this->groupBox4->Size = System::Drawing::Size(323, 55);
			this->groupBox4->TabIndex = 9;
			this->groupBox4->TabStop = false;
			this->groupBox4->Text = L"Видимость";
			// 
			// rbtInvisible
			// 
			this->rbtInvisible->AutoSize = true;
			this->rbtInvisible->Location = System::Drawing::Point(201, 23);
			this->rbtInvisible->Margin = System::Windows::Forms::Padding(4);
			this->rbtInvisible->Name = L"rbtInvisible";
			this->rbtInvisible->Size = System::Drawing::Size(87, 21);
			this->rbtInvisible->TabIndex = 9;
			this->rbtInvisible->Text = L"Невидим";
			this->rbtInvisible->UseVisualStyleBackColor = true;
			this->rbtInvisible->CheckedChanged += gcnew System::EventHandler(this, &MyForm::rbtInvisible_CheckedChanged);
			// 
			// rbtVisible
			// 
			this->rbtVisible->AutoSize = true;
			this->rbtVisible->Checked = true;
			this->rbtVisible->Location = System::Drawing::Point(12, 23);
			this->rbtVisible->Margin = System::Windows::Forms::Padding(4);
			this->rbtVisible->Name = L"rbtVisible";
			this->rbtVisible->Size = System::Drawing::Size(71, 21);
			this->rbtVisible->TabIndex = 8;
			this->rbtVisible->TabStop = true;
			this->rbtVisible->Text = L"Видим";
			this->rbtVisible->UseVisualStyleBackColor = true;
			this->rbtVisible->CheckedChanged += gcnew System::EventHandler(this, &MyForm::rbtVisible_CheckedChanged);
			// 
			// button3
			// 
			this->button3->Location = System::Drawing::Point(1224, 459);
			this->button3->Margin = System::Windows::Forms::Padding(4);
			this->button3->Name = L"button3";
			this->button3->Size = System::Drawing::Size(96, 55);
			this->button3->TabIndex = 10;
			this->button3->Text = L"Очистить";
			this->button3->UseVisualStyleBackColor = true;
			this->button3->Click += gcnew System::EventHandler(this, &MyForm::button3_Click_1);
			// 
			// btnDelete
			// 
			this->btnDelete->Location = System::Drawing::Point(1113, 459);
			this->btnDelete->Margin = System::Windows::Forms::Padding(4);
			this->btnDelete->Name = L"btnDelete";
			this->btnDelete->Size = System::Drawing::Size(92, 55);
			this->btnDelete->TabIndex = 11;
			this->btnDelete->Text = L"Удалить";
			this->btnDelete->UseVisualStyleBackColor = true;
			this->btnDelete->Click += gcnew System::EventHandler(this, &MyForm::btnDelete_Click);
			// 
			// btnChangeShape
			// 
			this->btnChangeShape->Location = System::Drawing::Point(153, 55);
			this->btnChangeShape->Margin = System::Windows::Forms::Padding(4);
			this->btnChangeShape->Name = L"btnChangeShape";
			this->btnChangeShape->Size = System::Drawing::Size(161, 46);
			this->btnChangeShape->TabIndex = 12;
			this->btnChangeShape->Text = L"Изменить тип фигуры";
			this->btnChangeShape->UseVisualStyleBackColor = true;
			this->btnChangeShape->Click += gcnew System::EventHandler(this, &MyForm::btnChangeShape_Click);
			// 
			// groupBox5
			// 
			this->groupBox5->BackColor = System::Drawing::Color::Transparent;
			this->groupBox5->Controls->Add(this->button1);
			this->groupBox5->Controls->Add(this->btnChangeShape);
			this->groupBox5->Controls->Add(this->comboBox1);
			this->groupBox5->Location = System::Drawing::Point(1113, 15);
			this->groupBox5->Margin = System::Windows::Forms::Padding(4);
			this->groupBox5->Name = L"groupBox5";
			this->groupBox5->Padding = System::Windows::Forms::Padding(4);
			this->groupBox5->Size = System::Drawing::Size(323, 107);
			this->groupBox5->TabIndex = 13;
			this->groupBox5->TabStop = false;
			this->groupBox5->Text = L"Фигуры";
			// 
			// btnSave
			// 
			this->btnSave->Location = System::Drawing::Point(1110, 522);
			this->btnSave->Margin = System::Windows::Forms::Padding(4);
			this->btnSave->Name = L"btnSave";
			this->btnSave->Size = System::Drawing::Size(323, 41);
			this->btnSave->TabIndex = 16;
			this->btnSave->Text = L"Сохранить";
			this->btnSave->UseVisualStyleBackColor = true;
			this->btnSave->Click += gcnew System::EventHandler(this, &MyForm::btnSave_Click);
			// 
			// btnUpload
			// 
			this->btnUpload->Location = System::Drawing::Point(1110, 571);
			this->btnUpload->Margin = System::Windows::Forms::Padding(4);
			this->btnUpload->Name = L"btnUpload";
			this->btnUpload->Size = System::Drawing::Size(323, 41);
			this->btnUpload->TabIndex = 17;
			this->btnUpload->Text = L"Загрузить сохранение";
			this->btnUpload->UseVisualStyleBackColor = true;
			this->btnUpload->Click += gcnew System::EventHandler(this, &MyForm::btnUpload_Click);
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 16);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackgroundImage = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"$this.BackgroundImage")));
			this->ClientSize = System::Drawing::Size(1475, 636);
			this->Controls->Add(this->btnRefresh);
			this->Controls->Add(this->button3);
			this->Controls->Add(this->btnUpload);
			this->Controls->Add(this->btnDelete);
			this->Controls->Add(this->btnSave);
			this->Controls->Add(this->groupBox5);
			this->Controls->Add(this->groupBox4);
			this->Controls->Add(this->groupBox3);
			this->Controls->Add(this->groupBox2);
			this->Controls->Add(this->groupBox1);
			this->Controls->Add(this->pictureBox1);
			this->DoubleBuffered = true;
			this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedSingle;
			this->Margin = System::Windows::Forms::Padding(4);
			this->Name = L"MyForm";
			this->Text = L"Lab 4";
			this->Load += gcnew System::EventHandler(this, &MyForm::MyForm_Load);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->EndInit();
			this->groupBox1->ResumeLayout(false);
			this->groupBox1->PerformLayout();
			this->groupBox2->ResumeLayout(false);
			this->groupBox2->PerformLayout();
			this->groupBox3->ResumeLayout(false);
			this->groupBox4->ResumeLayout(false);
			this->groupBox4->PerformLayout();
			this->groupBox5->ResumeLayout(false);
			this->ResumeLayout(false);

		}
#pragma endregion
private: System::Void button1_Click(System::Object^ sender, System::EventArgs^ e) {
	char type_figure = comboBox1->Text->ToString()[0];
	controller->GetInstance(g)->AddFigure(type_figure, pictureBox1->Width, pictureBox1->Height);
	if (controller->GetFigure1() != nullptr)
	{
		this->checkBox1->Visible = true;
	}
	if (controller->GetFigure2() != nullptr)
	{
		this->checkBox2->Visible = true;
	}
	if (controller->GetFigure3() != nullptr)
	{
		this->checkBox3->Visible = true;
	}
	if (controller->GetFigure4() != nullptr)
	{
		this->checkBox4->Visible = true;
	}
}
private: System::Void timer1_Tick(System::Object^ sender, System::EventArgs^ e) {
	controller->Move(rbTailed1->Checked);
	}
private: System::Void button2_Click(System::Object^ sender, System::EventArgs^ e) {
		timer1->Interval = 100;
		timer1->Start();
	}
private: System::Void btnStopTimer_Click(System::Object^ sender, System::EventArgs^ e) {
	timer1->Stop();
}
private: System::Void btnRefresh_Click(System::Object^ sender, System::EventArgs^ e) {
	controller->Refresh(pictureBox1->Width,pictureBox1->Height);
	timer1->Stop();
	rbtVisible->Checked = true;
}
private: System::Void button4_Click(System::Object^ sender, System::EventArgs^ e) {
	char param = comboBox2->Text[0];
	controller->ChangeColor(param);
}
private: System::Void button3_Click(System::Object^ sender, System::EventArgs^ e) {
	
}
private: System::Void checkBox1_CheckedChanged(System::Object^ sender, System::EventArgs^ e) {
	controller->ChangeEnabled(1, checkBox1->Checked);
}
private: System::Void rbtVisible_CheckedChanged(System::Object^ sender, System::EventArgs^ e) {
	controller->ChangeVisability(rbtVisible->Checked);
}
private: System::Void rbtInvisible_CheckedChanged(System::Object^ sender, System::EventArgs^ e) {
}
private: System::Void button3_Click_1(System::Object^ sender, System::EventArgs^ e) {
	this->checkBox1->Visible = false;
	this->checkBox2->Visible = false;
	this->checkBox3->Visible = false;
	this->checkBox4->Visible = false;
	this->checkBox1->Checked = false;
	this->checkBox2->Checked = false;
	this->checkBox3->Checked = false;
	this->checkBox4->Checked = false;
	check = 0;
	controller->Clear();
}
private: System::Void checkBox2_CheckedChanged(System::Object^ sender, System::EventArgs^ e) {
	controller->ChangeEnabled(2, checkBox2->Checked);
}
private: System::Void checkBox3_CheckedChanged(System::Object^ sender, System::EventArgs^ e) {
	controller->ChangeEnabled(3, checkBox3->Checked);
}
private: System::Void checkBox4_CheckedChanged(System::Object^ sender, System::EventArgs^ e) {
	controller->ChangeEnabled(4, checkBox4->Checked);
}
private: System::Void btnDelete_Click(System::Object^ sender, System::EventArgs^ e) {
	controller->Delete();
	if (controller->GetFigure1() == nullptr)
	{
		this->checkBox1->Visible = false;
		this->checkBox1->Checked = false;
	}
	if (controller->GetFigure2() == nullptr)
	{
		this->checkBox2->Visible = false;
		this->checkBox2->Checked = false;
	}
	if (controller->GetFigure3() == nullptr)
	{
		this->checkBox3->Visible = false;
		this->checkBox3->Checked = false;
	}
	if (controller->GetFigure4() == nullptr)
	{
		this->checkBox4->Visible = false;
		this->checkBox4->Checked = false;
	}
}
private: System::Void btnChangeShape_Click(System::Object^ sender, System::EventArgs^ e) {
	char type_figure = comboBox1->Text->ToString()[0];
	controller->ChangeShape(type_figure);
}
private: System::Void rbTailed1_CheckedChanged(System::Object^ sender, System::EventArgs^ e) {
}
private: System::Void MyForm_Load(System::Object^ sender, System::EventArgs^ e) {
}
private: System::Void btnSave_Click(System::Object^ sender, System::EventArgs^ e) {
	Memento^ memento = controller->Save();
	Scrambler^ data = gcnew Scrambler(memento);
	data->Serialize();
}
	private: System::Void btnUpload_Click(System::Object^ sender, System::EventArgs^ e)
	{
		timer1->Stop();
		Scrambler^ data = gcnew Scrambler();
		Memento^ memento = data->Deserialize();
		controller->Upload(memento);
		if (controller->GetFigure1() != nullptr)
		{
			this->checkBox1->Visible = true;
		}
		if (controller->GetFigure2() != nullptr)
		{
			this->checkBox2->Visible = true;
		}
		if (controller->GetFigure3() != nullptr)
		{
			this->checkBox3->Visible = true;
		}
		if (controller->GetFigure4() != nullptr)
		{
			this->checkBox4->Visible = true;
		}
	}
};
}
