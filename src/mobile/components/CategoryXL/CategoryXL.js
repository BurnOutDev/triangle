import React from 'react'
import { View } from 'react-native'
import { Text } from '@ui-kitten/components'
import CategoryXLList from './CategoryXLList'
import axios from '../../axios'

const CategoryXL = (props) => {
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
            <CategoryXLList restaurants={data.restaurants} />
        </View>
    )
}

export default CategoryXL