# 資料庫程式設計 期末報告

## 專案名稱
屏東大學特約商店搜尋器

## 目的與內容
學生會公關部簽了許多特約商店，在IG的宣傳無法直接搜尋店家的特約內容，因此我們建立了特約商店的資料庫。</br>
透過使用SQL語法和資料庫連接呈現店家資訊與搜尋的結果，讓特約商店變得方便查詢。</br>
在店家資訊中使用webbrowers呈現店家在地圖上的位置，讓使用者更方便的了解店家的相關資訊。</br>

## 參與人員
CBE109042 陳歆宜
CBE109048 徐采碟
CBE109050 楊麗芳
CEI107022 林冠渝

## 預期效益
希望藉由此特約搜尋器，可以讓屏東大學的的學生更方便尋找相關的特約店家以及其優惠內容。</br>
使使用特約的同學越來越多，不僅促進學生對學生會特約商店的好感度，也增加店家的人流。

## 應用程式功能
我們先建立一Excel整理特約商店資訊，並依商店性質分類(#肚子好餓、#渴了嗎？、#清涼一下 等)。</br>依照資料建立一特約商店的資料庫，並使用listbox呈現店家列表。

除了列表外，我們也建立搜尋功能。</br>
當搜尋欄為空，會提示使用者輸入想尋找的店家，當再次點擊搜尋欄，提示文字將會自動消失；</br>
搜尋結果為0時，也會提示使用者再次點擊放大鏡回到主頁面，顯示所有資料。</br>


為了讓使用者方便使用，我們提供了4種搜尋店家的方法。

第一種為類別搜尋，使用關鍵字「#」前綴類別，即可找到所有該類別的店家。</br>
第二種為輸入「店家相關字」，即使店家名稱過長，我們也可以找到含有「相關字」的店家。</br>
第三種為輸入「路段相關字」，想知道某條路上有哪些店家，可以輸入路段相關字(最後一個字為「路」、「街」、「段」皆可)進行搜尋。</br>
第四種則是隨機選擇店家，可以讓使用者去隨機存取其中一家特約商店的資訊。除了讓不知道想吃什麼、想玩什麼的困擾消散以外，還可以讓同學多認識沒看過的店家。

使用者點選該列後，會被導向至新視窗，新視窗內有店家類別、店名、特約內容、電話、地址及地圖顯示器。</br>
且使用者可以點選多個店家來相互比較優惠資訊。

## 實際使用狀況介紹

![](https://i.imgur.com/aEbyZox.png)
![](https://i.imgur.com/kmYdEDK.png)
![](https://i.imgur.com/sa3R3u8.png)