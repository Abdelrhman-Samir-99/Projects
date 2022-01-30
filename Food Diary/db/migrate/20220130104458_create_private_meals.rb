class CreatePrivateMeals < ActiveRecord::Migration[6.1]
  def change
    create_table :private_meals do |t|

      t.timestamps
    end
  end
end
