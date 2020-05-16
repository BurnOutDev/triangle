import React from 'react'
import { View } from 'react-native'
import { Text } from '@ui-kitten/components'
import CategoryList from './CategoryList'
import { AuthContext } from '../../screens/context'
import axios from '../../axios'

const Category = (props) => {
    const [data, setData] = React.useState(null)

    React.useEffect(() => { if (!data) getData() }, []);

    const getData = async () => {
        const response = await axios.get('Restaurant/RestaurantsPerCategory')
        setData(response.data)
    }

    return (
        <View style={{ margin: 15 }}>
            <Text category='h3'>{props.title}</Text>
            <CategoryList restaurants={data} />
        </View>
    )
}

export default Category