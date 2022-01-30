class CreatePublicMeals < ActiveRecord::Migration[6.1]
  def change
    create_table :public_meals do |t|

      t.timestamps
    end
  end
end
