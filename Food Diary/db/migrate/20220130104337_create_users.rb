class CreateUsers < ActiveRecord::Migration[6.1]
  def change
    create_table :users do |t|
      t.string :First_Name, null: false
      t.string :Last_Name, null: false
      t.string :Password, null: false
      t.string :Mail, null: false, unique: true
      t.integer :Weight, default: 0, null: false
      t.integer :Calories_today, default: 0, null: false
      t.string :Phone_Number, null: false, unique: true
     

      t.timestamps
    end
  end
end
