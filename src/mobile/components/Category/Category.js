import React from 'react'
import { View } from 'react-native'
import { Text } from '@ui-kitten/components'
import CategoryList from './CategoryList'
import { AuthContext } from '../../screens/context'
import axios from '../../axios'

const Category = (props) => {
    const [data, setData] = React.useState(null)

    React.useEffect(() => { if (data == null) getData() }, []);

    const getData = async () => {
        const response = await axios.post('Restaurant/RestaurantsPerCategory', {
            categoryName: props.title
        })

        setData(response.data)
    }

    return (data &&
        <View style={{ margin: 15 }}>
            <Text category='h3'>{data.categoryName}</Text>
            <CategoryList restaurants={data.restaurants} />
        </View>
    )
}

export default Category