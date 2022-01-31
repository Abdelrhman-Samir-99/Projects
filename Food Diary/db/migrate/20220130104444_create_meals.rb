class CreateMeals < ActiveRecord::Migration[6.1]
  def change
    create_table :meals do |t|
      t.string :Name, null: false
      t.string :Description
      t.integer :Calories
      
      t.timestamps
    end
  end
end
