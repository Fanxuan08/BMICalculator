# BMI Calculator Pro (進階版身體質量指數計算機)

## 專案簡介

本專案為一個具備完整輸入驗證與資料紀錄功能的 BMI 計算機。除了基礎的體位計算，亦針對操作流程與資料儲存進行了進階擴充。

### 基礎功能

* **BMI 數值計算**
  * 讀取使用者輸入的身高（公分）與體重（公斤），自動進行單位轉換並算出 BMI 值。
* **體位判定與視覺提示**
  * 根據計算結果判斷所屬體位（如：健康體位、輕度肥胖等），並搭配低飽和度的介面底色呈現判定結果。
* **輸入防呆機制**
  * 內建數值驗證，確保輸入值為大於零的有效數字。發生錯誤時直接於介面文字提示，避免使用彈跳視窗打斷使用者操作。

### 進階創意擴充

* **無滑鼠操作**
  * 設定 `TabIndex` 與 `AcceptButton`，使用者可全程透過 `Tab` 與 `Enter` 鍵完成「輸入 ➔ 跳格 ➔ 計算」。
* **目標體重反推**
  * 自動以標準體位 (BMI = 22) 為基準，反向推算並提示使用者距離目標尚需「增重 / 減重」的具體公斤數。
* **本地端資料持久化**
  * **歷史紀錄清單**：動態將每次的計算結果更新於畫面 `ListBox`。
  * **檔案匯入與匯出**：結合 `OpenFileDialog` 與 `SaveFileDialog`，支援將紀錄匯出成 `.txt` 檔案，亦可隨時載入舊有紀錄，實現完整的資料管理。

## 執行說明

### 1. 基礎操作與防呆機制
* **數值輸入**：使用者需於對應欄位輸入身高（公分）與體重（公斤）。

   <img width="340" height="150" alt="螢幕擷取畫面 2026-04-01 214346" src="https://github.com/user-attachments/assets/0de68196-a785-466c-b6f4-a7fd806e903f" />

* **錯誤攔截**：若使用者輸入非數字字元（如英文字母、特殊符號）、空白，或是輸入小於等於零的無效數值，系統將中斷計算，並跳出警告視窗提示「身高必須大於零」或「請輸入有效的數值」。

  
   <img width="150" height="235" alt="螢幕擷取畫面 2026-04-01 214408" src="https://github.com/user-attachments/assets/7a5ec566-95fc-4af6-8ca7-433826746faa" />  <img width="150" height="239" alt="螢幕擷取畫面 2026-04-01 214432" src="https://github.com/user-attachments/assets/b1038ec1-733e-4ddc-aa85-60a904dac1e8" />  <img width="150" height="237" alt="螢幕擷取畫面 2026-04-01 214456" src="https://github.com/user-attachments/assets/e58d5e7a-4ac6-4ca7-af64-a2496a3a4349" />  <img width="150" height="238" alt="螢幕擷取畫面 2026-04-01 214509" src="https://github.com/user-attachments/assets/71f6dcaa-ac0a-4202-8579-c0a2ffa8ceb5" />


### 2. 計算結果與顏色變化
輸入正確數值並按下計算後，系統會顯示 BMI 數值與對應的體位，並將結果區塊的背景變換為對應的顏色：
* **體重過輕** (BMI < 18.5)：顯示為粉藍色。
* **健康體位** (18.5 ≦ BMI < 24)：顯示為粉綠色。
* **體位過重** (24 ≦ BMI < 27)：顯示為粉橘色。
* **輕度肥胖** (27 ≦ BMI < 30)：顯示為蜜桃橘色。
* **中度肥胖** (30 ≦ BMI < 35)：顯示為粉紅色。
* **重度肥胖** (BMI ≧ 35)：顯示為粉紫色。
  
   <img width="300" height="107" alt="螢幕擷取畫面 2026-04-01 215704" src="https://github.com/user-attachments/assets/1b199117-dfed-425b-a00e-d55b00b4faab" />  <img width="300" height="108" alt="螢幕擷取畫面 2026-04-01 215742" src="https://github.com/user-attachments/assets/b3565a58-3e5e-4243-ae4d-5c0cad77076f" />  <img width="300" height="109" alt="螢幕擷取畫面 2026-04-01 215759" src="https://github.com/user-attachments/assets/797e1dc2-7dd5-4c3f-bac4-da70ca87a53c" />
   <img width="300" height="108" alt="螢幕擷取畫面 2026-04-01 215809" src="https://github.com/user-attachments/assets/e23520ee-1c3a-4988-b6eb-5096f93d157b" />  <img width="300" height="108" alt="螢幕擷取畫面 2026-04-01 215822" src="https://github.com/user-attachments/assets/7cc651fc-e04e-43cc-a0c4-f5f2d3b0ce0d" />  <img width="300" height="108" alt="螢幕擷取畫面 2026-04-01 215836" src="https://github.com/user-attachments/assets/6aabe62f-8bc7-46b0-812c-9fc9cb30a1dd" />


### 3. 目標體重建議
系統會同步根據使用者的身高，以標準 BMI 值 22 為基準進行反推。
* 若落在健康體位，會給予「維持得非常完美」的正面鼓勵。
* 若為其他體位，系統會精準算出並顯示「您大約還需要增重 / 減重 X 公斤」，提供具體目標。
  
   <img width="300" height="146" alt="螢幕擷取畫面 2026-04-01 221059" src="https://github.com/user-attachments/assets/66c4342e-9d74-4343-b484-e66f417460f5" />  <img width="300" height="146" alt="螢幕擷取畫面 2026-04-01 221045" src="https://github.com/user-attachments/assets/17fe6922-3418-4b82-88e1-2b7fb004c92e" />


### 4. 歷史紀錄與檔案管理
* **自動紀錄**：每次成功計算後，包含時間、身高、體重與 BMI 的完整資訊會自動新增至畫面右側的清單最上方。
  
   <img width="400" height="439" alt="螢幕擷取畫面 2026-04-01 221309" src="https://github.com/user-attachments/assets/cf8cdcee-e20b-4020-9cd5-27203b41070e" />

* **清空畫面**：點擊「清空」按鈕，可一鍵淨空畫面上的清單，不影響已存檔的資料。
  
   <img width="400" height="436" alt="螢幕擷取畫面 2026-04-01 221402" src="https://github.com/user-attachments/assets/0c150735-65d1-4c3d-8d5d-d2c7e03b2354" />

* **匯出檔案**：點擊「匯出」按鈕，系統會開啟存檔視窗，讓使用者將當前清單的所有資料存成純文字檔 (.txt) 至電腦中。

   <img width="400" height="707" alt="螢幕擷取畫面 2026-04-01 221526" src="https://github.com/user-attachments/assets/72cac431-bee1-4318-9efe-74d1fefd86ce" />  <img width="350" height="285" alt="螢幕擷取畫面 2026-04-01 221553" src="https://github.com/user-attachments/assets/6104daa9-5bb3-42a4-a34c-200d578a8266" />


* **載入紀錄**：點擊「載入」按鈕，可從電腦中挑選過去存檔的文字檔，系統會將舊資料讀取出來，並按時間新舊順序整齊排列回畫面清單上。

    <img width="450" height="707" alt="螢幕擷取畫面 2026-04-01 221611" src="https://github.com/user-attachments/assets/8bdd75e9-9089-4003-8540-69003a7f75c7" />  <img width="250" height="436" alt="螢幕擷取畫面 2026-04-01 221626" src="https://github.com/user-attachments/assets/5e93c8d3-04bb-43fc-bad9-effaf5f71188" />


