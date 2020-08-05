import React from 'react'
import { View } from 'react-native'
import { Text } from '@ui-kitten/components'
import CategoryList from './CategoryList'
import { AuthContext } from '../../screens/context'
import axios from '../../axios'
import { Splash } from '../../screens/Screens'
import api from '../../variables/api'

const Category = (props) => {
    const [data, setData] = React.useState(null)

    React.useEffect(() => { if (data == null) getData() }, []);

    const getData = async () => {
        const response = await axios.post(api.restaurant.restaurantsPerCategory, {
            categoryName: props.title
        })

        setData(response.data)
    }

    return (
        <View style={{ margin: 15 }}>
            {data ? <>
                <Text category='h3'>{data.categoryName}</Text>
                <CategoryList restaurants={data.restaurants} />
            </> : <Splash />}
        </View>
    )
}

export default Category