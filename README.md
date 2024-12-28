# Monopoly大富翁計分程式   

  ## 創立緣由   
    每逢佳節時刻，與親友聚在一起玩場大富翁總是歡樂無比，但最怕玩到一半必須去洗碗或者臨時被叫去踏青，為了避免遊戲紀錄無法被有效保存的問題，這個小專案提供了即時存取的功能，那怕是晚點完、明天玩、甚至是明年玩都可以讀取未完成的遊戲進度。   
  
  ## 專案功能介紹     
  **1. 即時存取**   
  專案可自動儲存遊戲進度，例如:目前玩家、所有玩家的金額等遊戲資訊   

  **2. 建立遊戲**
  只要輸入遊玩人數，就可立刻開局!(建議不要超過10人)   

  **3. 回合機制**
  UI會提示當前玩家是誰，可依照操作情形調整金額   

  ## API說明

  **GameHistory**   
  /api/GameHistory (Get)回傳所有賽局得紀錄   
  /api/GameHistory (POST)建立新的賽局   
  /api/GameHistory/{id} (Get)回傳特定id的賽局資料   
  /api/GameHistory/{id} (Put)移除賽局紀錄   

  **Players**   
  /api/Players/{token} (Get)回傳特定賽局的所有玩家資料   
  /api/Players/{token} (Put)切換玩家    

  **RoundData**   
  /api/RoundData (post)紀錄玩家該回合的金額異動   
  /api/RoundData (Put)退回上一位玩家   
  
  
