import React from 'react'
import { View } from 'react-native'
import { Text } from '@ui-kitten/components'
import CategoryList from './CategoryList'
import axios from '../../axios'
import { Splash } from '../../screens/Screens'
import api from '../../variables/api'
import CategoryXLList from '../CategoryXL/CategoryXLList'

const Category = ({ title, horizontal }) => {
    const [data, setData] = React.useState(null)

    React.useEffect(() => { if (data == null) getData() }, []);

    const getData = async () => {
        const response = await axios.post(api.restaurant.restaurantsPerCategory, {
            categoryName: title
        })

        setData(response.data)
    }

    return (
        <View style={{ margin: 15 }}>
            {data ? <>
                <Text category='h3'>{data.categoryName}</Text>
                {horizontal ?
                    <CategoryXLList restaurants={data.restaurants} />
                    : <CategoryList restaurants={data.restaurants} />}
            </> : <Splash />}
        </View>
    )
}

export default Category