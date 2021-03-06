import Vue from 'vue'
import Vuex from 'vuex'
import { auth } from './modules/auth'
import { dashboard } from './modules/dashboard'
import { requestlist } from './modules/requestlist'
// import { requestDetails } from './modules/requestDetails'
import { service } from './modules/service'
import { requestDetails } from './modules/requestDetails'
import { comment } from './modules/comment'
import { staff } from './modules/staff'
Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    _breadcrumbs: []
  },
  getters: {
    _getBreadcrumbs (state) {
      return state._breadcrumbs
    }
  },
  mutations: {
    _addBreadcrubs (state, object) {
      if (state._breadcrumbs.length > 0) {
        state._breadcrumbs[state._breadcrumbs.length - 1].disabled = false
      }
      state._breadcrumbs.push(object)
    },
    _addListBreadcrubs (state, list) {
      this._removeAll()
      list.forEach(element => {
        state._breadcrumbs.push(element)
      })
    },
    _removeAll (state, object) {
      state._breadcrumbs = []
    }
  },
  actions: {},
  modules: {
    auth,
    dashboard,
    requestlist,
    service,
    requestDetails,
    comment,
    staff
  }
})
